using Dealer.Api.Models.ExternalApplicants;
using System.Collections.Generic;
using System.IO;

namespace Dealer.Api.Brokers.Spreadsheets
{
    public interface ISpreadsheetBroker
    {
        List<ExternalApplicant> ImportApplicants(MemoryStream memoryStream);
    }
}