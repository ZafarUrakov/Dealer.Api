using System.Collections.Generic;
using Dealer.Api.Models.ExternalApplicants;
using Dealer.Api.Models.ExternalApplicants.Exceptions;
using Dealer.Api.Models.Processings.Exceptions;
using Xeptions;

namespace Dealer.Api.Services.Processings.ExternalApplicants
{
    public partial class ExternalApplicantProcessingService
    {
        private delegate List<ExternalApplicant> ReturningExternalApplicantsFunction();

        private List<ExternalApplicant> TryCatch(ReturningExternalApplicantsFunction returningExternalApplicantsFunction)
        {
            try
            {
                return returningExternalApplicantsFunction();
            }
            catch (ExternalApplicantValidationException externalApplicantValidationException)
            {
                throw CreateAndLogValidationException(externalApplicantValidationException.InnerException as Xeption);
            }
            catch(EmptySpreadsheetException emptySpreadsheetException)
            {
                throw CreateAndLogValidationException(emptySpreadsheetException);
            }
        }

        private ExternalApplicantsProcessingValidationException CreateAndLogValidationException(Xeption exception)
        {
            var externalApplicantsProcessingValidationException =
                new ExternalApplicantsProcessingValidationException(exception);

            this.loggingBroker.LogError(externalApplicantsProcessingValidationException);

            return externalApplicantsProcessingValidationException;
        }
    }
}
