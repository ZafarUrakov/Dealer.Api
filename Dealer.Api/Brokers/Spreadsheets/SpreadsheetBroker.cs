using Dealer.Api.Models.ExternalApplicants;
using System.Collections.Generic;
using System.IO;

namespace Dealer.Api.Brokers.Spreadsheets
{
    public class SpreadsheetBroker : ISpreadsheetBroker
    {
        public List<ExternalApplicant> ImportApplicants(MemoryStream memoryStream)
        {
            throw new System.NotImplementedException();
        }
    }
}