using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dealer.Api.Models.ExternalApplicants;
using Microsoft.AspNetCore.Http;

namespace Dealer.Api.Services.Processings.Spreadsheets
{
    public class SpreadsheetProcessingService : ISpreadsheetProcessingService
    {
        public ValueTask<List<ExternalApplicant>> ReadExternalApplicant(IFormFile formFile)
        {
            throw new NotImplementedException();
        }
    }
}