using System;
using System.Collections.Generic;
using Dealer.Api.Models.Applicants;
using Dealer.Api.Models.ExternalApplicants;
using Dealer.Api.Models.ExternalApplicants.Exceptions;
using Xeptions;

namespace Dealer.Api.Services.Foundations.ExternalApplicants
{
    public partial class ExternalApplicantService
    {
        private delegate List<ExternalApplicant> ReturningExternalApplicantsFunction();

        private List<ExternalApplicant> TryCatch(ReturningExternalApplicantsFunction returningExternalApplicantsFunction)
        {
            try
            {
                return returningExternalApplicantsFunction();
            }
            catch (NullExternalApplicantException nullExternalApplicantException)
            {
                throw CreateAndLogValidationException(nullExternalApplicantException);
            }
            catch(InvalidExternalApplicantException invalidExternalApplicantException)
            {
                throw CreateAndLogValidationException(invalidExternalApplicantException);
            }
        }

        private ExternalApplicantValidationException CreateAndLogValidationException(Xeption exception)
        {
            var externalApplicantValidationException =
                new ExternalApplicantValidationException(exception);

            this.loggingBroker.LogError(externalApplicantValidationException);

            return externalApplicantValidationException;
        }
    }
}
