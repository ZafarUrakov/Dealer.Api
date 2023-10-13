using System.Collections.Generic;
using System.IO;
using Dealer.Api.Brokers.Loggings;
using Dealer.Api.Brokers.Spreadsheets;
using Dealer.Api.Models.ExternalApplicants;

namespace Dealer.Api.Services.Foundations.ExternalApplicants
{
    public partial class ExternalApplicantService : IExternalApplicantService
    {
        private readonly ISpreadsheetBroker spreadsheetBroker;
        private readonly ILoggingBroker loggingBroker;

        public ExternalApplicantService(
            ISpreadsheetBroker spreadsheetBroker,
            ILoggingBroker loggingBroker)
        {
            this.spreadsheetBroker = spreadsheetBroker;
            this.loggingBroker = loggingBroker;
        }

        public List<ExternalApplicant> ReadExternalApplicants(string filePath) =>
        TryCatch(() =>
        {
            List<ExternalApplicant> externalApplicants =
                this.spreadsheetBroker.ImportApplicants(filePath);

            ValidateExternalApplicantsOnImport(externalApplicants);

            return externalApplicants;
        });
    }
}