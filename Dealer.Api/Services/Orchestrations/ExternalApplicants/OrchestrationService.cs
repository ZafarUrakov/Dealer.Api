using System;
using System.Threading.Tasks;
using Dealer.Api.Models.Applicants;
using Dealer.Api.Models.ExternalApplicants;
using Dealer.Api.Models.Groups;
using Dealer.Api.Services.Processings.Applicants;
using Dealer.Api.Services.Processings.Groups;
using Dealer.Api.Services.Processings.Spreadsheets;
using Microsoft.AspNetCore.Http;

namespace Dealer.Api.Services.Orchestrations.ExternalApplicants
{
    public class OrchestrationService : IOrchestrationService
    {
        private readonly IApplicantProcessingService applicantProcessingService;
        private readonly IGroupProcessingService groupProcessingService;
        private readonly ISpreadsheetProcessingService spreadsheetProcessingService;

        public OrchestrationService(
            ISpreadsheetProcessingService spreadsheetProcessingService,
            IGroupProcessingService groupProcessingService,
            IApplicantProcessingService applicantProcessingService)
        {
            this.spreadsheetProcessingService = spreadsheetProcessingService;
            this.groupProcessingService = groupProcessingService;
            this.applicantProcessingService = applicantProcessingService;
        }

        public async Task ProcessImportRequest(IFormFile formFile)
        {
            var validExternalApplicants =
                await spreadsheetProcessingService.ReadExternalApplicant(formFile);

            foreach (var externalApplicant in validExternalApplicants)
            {
                var ensureGroup =
                    await groupProcessingService.EnsureGroupExistsByName(externalApplicant.GroupName);

                var applicant = MapToApplicant(externalApplicant, ensureGroup);

                await applicantProcessingService.AddApplicantAsync(applicant);
            }
        }

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
                GroupId = externalApplicant.GroupId,
                GroupName = externalApplicant.GroupName
            };
        }
    }
}