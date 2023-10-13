using Dealer.Api.Models.ExternalApplicants;
using System.Collections.Generic;

namespace Dealer.Api.Services.Foundations.Spreadsheets
{
    public interface ISpreadsheetService
    {
        List<ExternalApplicant> ValidateApplicantNotNull(string filePath);
    }
}