using Dealer.Api.Models.Applicants;
using Dealer.Api.Models.Applicants.Exceptions;
using System.Threading.Tasks;
using Xeptions;

namespace Dealer.Api.Services.Foundations.Applicants
{
    public partial class ApplicantService
    {
        private delegate ValueTask<Applicant> ReturningApplicantFunction();

        private async ValueTask<Applicant> TryCatch(ReturningApplicantFunction returningApplicantFunction)
        {
            try
            {
                return await returningApplicantFunction();
            }
            catch (NullApplicantExeption nullApplicantExeption)
            {
                throw CreateAndLogValidationException(nullApplicantExeption);
            }
            catch (InvalidApplicantException invalidApplicantException)
            {
                throw CreateAndLogValidationException(invalidApplicantException);
            }
        }

        private ApplicantValidationException CreateAndLogValidationException(Xeption exception)
        {
            var applicantValidationException =
                new ApplicantValidationException(exception);

            this.loggingBroker.LogError(applicantValidationException);

            return applicantValidationException;
        }
    }
}
