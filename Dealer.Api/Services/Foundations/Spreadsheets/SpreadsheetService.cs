using Dealer.Api.Brokers.Spreadsheets;
using Dealer.Api.Models.Applicants.Exceptions;
using Dealer.Api.Models.Applicants;
using System.Collections.Generic;
using Dealer.Api.Models.ExternalApplicants;

namespace Dealer.Api.Services.Foundations.Spreadsheets
{
    public class SpreadsheetService : ISpreadsheetService
    {
        SpreadsheetBroker spreadsheetBroker = new SpreadsheetBroker();

        public SpreadsheetService(SpreadsheetBroker spreadsheetBroker)
        {
            this.spreadsheetBroker = spreadsheetBroker;
        }

        public List<ExternalApplicant> ValidateApplicantNotNull(string filePath)
        {
            var applicants = spreadsheetBroker.ImportApplicants(filePath);
            List<ExternalApplicant> filteredApplicants = new List<ExternalApplicant>();

            foreach (var applicant in applicants)
            {
                if (applicant != null)
                    filteredApplicants.Add(applicant);
                else
                    throw new NullApplicantExeption();
            }

            return filteredApplicants;
        }
    }
}