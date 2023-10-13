using Dealer.Api.Brokers.Loggings;
using Dealer.Api.Models.Applicants.Exceptions;
using Dealer.Api.Models.ExternalApplicants;
using Dealer.Api.Services.Foundations.Spreadsheets;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dealer.Api.Services.Processings.Spreadsheets
{
    public partial class SpreadsheetProcessingService : ISpreadsheetProcessingService
    {
        private readonly SpreadsheetService spreadsheetService;
        private readonly LoggingBroker loggingBroker;

        public SpreadsheetProcessingService(
            SpreadsheetService spreadsheetService,
            LoggingBroker loggingBroker)
        {
            this.spreadsheetService = spreadsheetService;
            this.loggingBroker = loggingBroker;
        }
        InvalidApplicantException invalidApplicantException = new InvalidApplicantException();

        public async ValueTask<List<ExternalApplicant>> ReadExternalApplicant(string filePath)
        {
            var notNullExternalApplicants = this.spreadsheetService.ValidateApplicantNotNull(filePath);

            var validExteranlApplicants = new ValueTask<List<ExternalApplicant>>();

            foreach (var externalApplicant in notNullExternalApplicants)
            {
                await ValidateExternalApplicantOnAdd(validExteranlApplicants, externalApplicant);
            }

            return await validExteranlApplicants;
        }
    }
}
