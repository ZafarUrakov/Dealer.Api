using System.Collections.Generic;
using System.IO;
using Dealer.Api.Models.ExternalApplicants;

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