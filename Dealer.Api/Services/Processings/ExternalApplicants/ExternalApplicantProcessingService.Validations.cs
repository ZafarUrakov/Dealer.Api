using Dealer.Api.Models.ExternalApplicants;
using Dealer.Api.Models.Processings.Exceptions;
using System.Collections.Generic;

namespace Dealer.Api.Services.Processings.ExternalApplicants
{
    public partial class ExternalApplicantProcessingService
    {
        private static void ValidateExternalApplicantsExists(List<ExternalApplicant> validExternalApplicants)
        {
            if (validExternalApplicants is null
               || validExternalApplicants.Count is 0)
            {
                throw new EmptySpreadsheetException();
            }
        }
    }
}
