using System.Collections.Generic;
using System.Threading.Tasks;
using Dealer.Api.Models.ExternalApplicants;
using Microsoft.AspNetCore.Http;

namespace Dealer.Api.Services.Processings.Spreadsheets
{
    public interface ISpreadsheetProcessingService
    {
        ValueTask<List<ExternalApplicant>> ReadExternalApplicant(string filePath);
    }
}