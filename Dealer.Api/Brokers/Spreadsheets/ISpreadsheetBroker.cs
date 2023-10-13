using System.Collections.Generic;
using System.IO;
using Dealer.Api.Models.ExternalApplicants;

namespace Dealer.Api.Brokers.Spreadsheets
{
    public interface ISpreadsheetBroker
    {
        List<ExternalApplicant> ImportApplicants(MemoryStream memoryStream);
    }
}