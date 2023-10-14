using Dealer.Api.Brokers.Loggings;
using Dealer.Api.Models.ExternalApplicants;
using Dealer.Api.Services.Foundations.ExternalApplicants;
using System.Collections.Generic;
using System.IO;

namespace Dealer.Api.Services.Processings.ExternalApplicants
{
    public partial class ExternalApplicantProcessingService : IExternalApplicantProcessingService
    {
        private readonly IExternalApplicantService externalApplicantService;
        private readonly ILoggingBroker loggingBroker;

        public ExternalApplicantProcessingService(IExternalApplicantService externalApplicantService, ILoggingBroker loggingBroker)
        {
            this.externalApplicantService = externalApplicantService;
            this.loggingBroker = loggingBroker;
        }

        public List<ExternalApplicant> GetValidExternalApplicants(MemoryStream memoryStream) =>
        TryCatch(() =>
        {
            List<ExternalApplicant> validExternalApplicants =
                this.externalApplicantService.ReadExternalApplicants(memoryStream);
            ValidateExternalApplicantsExists(validExternalApplicants);

            validExternalApplicants.ForEach(externalApplicant =>
            {
                if (string.IsNullOrWhiteSpace(externalApplicant.FirstName)
                    || string.IsNullOrWhiteSpace(externalApplicant.PhoneNumber)
                    || string.IsNullOrWhiteSpace(externalApplicant.Email))
                {
                    validExternalApplicants.Remove(externalApplicant);
                }
            });

            return validExternalApplicants;
        });
    }
}