using Xeptions;

namespace Dealer.Api.Models.Processings.Exceptions
{
    public class EmptySpreadsheetException : Xeption
    {
        public EmptySpreadsheetException()
            : base(message: "Spreadsheet is empty")
        { }
    }
}
