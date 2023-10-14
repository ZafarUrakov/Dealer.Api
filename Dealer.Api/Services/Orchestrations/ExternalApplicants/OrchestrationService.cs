using Dealer.Api.Brokers.Loggings;
using Dealer.Api.Models.Applicants;
using Dealer.Api.Models.ExternalApplicants;
using Dealer.Api.Models.Groups;
using Dealer.Api.Services.Processings.Applicants;
using Dealer.Api.Services.Processings.ExternalApplicants;
using Dealer.Api.Services.Processings.Groups;
using System;
using System.Threading.Tasks;

namespace Dealer.Api.Services.Orchestrations.ExternalApplicants
{
    public partial class OrchestrationService : IOrchestrationService
    {
        private readonly IApplicantProcessingService applicantProcessingService;
        private readonly IGroupProcessingService groupProcessingService;
        private readonly IExternalApplicantProcessingService externalApplicantProcessingService;
        private readonly ILoggingBroker loggingBroker;

        public OrchestrationService(
            IGroupProcessingService groupProcessingService,
            IApplicantProcessingService applicantProcessingService,
            ILoggingBroker loggingBroker,
            IExternalApplicantProcessingService externalApplicantProcessingService)
        {
            this.groupProcessingService = groupProcessingService;
            this.applicantProcessingService = applicantProcessingService;
            this.loggingBroker = loggingBroker;
            this.externalApplicantProcessingService = externalApplicantProcessingService;
        }

        public Task ProcessImportRequest(string filePath) =>
        TryCatch(async () =>
        {
            var validExternalApplicants =
                this.externalApplicantProcessingService.GetValidExternalApplicants(filePath);

            foreach (var externalApplicant in validExternalApplicants)
            {
                var ensureGroup =
                    await groupProcessingService
                    .EnsureGroupExistsByName(externalApplicant.GroupName);

                var applicant = MapToApplicant(externalApplicant, ensureGroup);

                await applicantProcessingService.AddApplicantAsync(applicant);
            }
        });

        private Applicant MapToApplicant(ExternalApplicant externalApplicant, Group ensureGroup)
        {
            return new Applicant
            {
                ApplicantId = Guid.NewGuid(),
                FirstName = externalApplicant.FirstName,
                LastName = externalApplicant.LastName,
                BirthDate = externalApplicant.BirthDate,
                Email = externalApplicant.Email,
                PhoneNumber = externalApplicant.PhoneNumber,
                GroupId = ensureGroup.GroupId,
                GroupName = ensureGroup.GroupName
            };
        }
    }
}