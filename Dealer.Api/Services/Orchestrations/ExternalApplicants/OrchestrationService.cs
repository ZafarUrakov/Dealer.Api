using Dealer.Api.Brokers.Loggings;
using Dealer.Api.Models.Applicants;
using Dealer.Api.Models.ExternalApplicants;
using Dealer.Api.Models.Groups;
using Dealer.Api.Services.Processings.Applicants;
using Dealer.Api.Services.Processings.Groups;
using Dealer.Api.Services.Processings.Spreadsheets;
using System;
using System.Threading.Tasks;

namespace Dealer.Api.Services.Orchestrations.ExternalApplicants
{
    public partial class OrchestrationService : IOrchestrationService
    {
        private readonly IApplicantProcessingService applicantProcessingService;
        private readonly IGroupProcessingService groupProcessingService;
        private readonly ISpreadsheetProcessingService spreadsheetProcessingService;
        private readonly ILoggingBroker loggingBroker;

        public OrchestrationService(
            ISpreadsheetProcessingService spreadsheetProcessingService,
            IGroupProcessingService groupProcessingService,
            IApplicantProcessingService applicantProcessingService,
            ILoggingBroker loggingBroker)
        {
            this.spreadsheetProcessingService = spreadsheetProcessingService;
            this.groupProcessingService = groupProcessingService;
            this.applicantProcessingService = applicantProcessingService;
            this.loggingBroker = loggingBroker;
        }

        public Task ProcessImportRequest(string filePath) =>
        TryCatch(async () =>
        {
            var validExternalApplicants =
                await spreadsheetProcessingService.ReadExternalApplicant(filePath);

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