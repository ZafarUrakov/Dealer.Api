using Xeptions;

namespace Dealer.Api.Models.ExternalApplicants.Exceptions
{
    public class ExternalApplicantValidationException : Xeption
    {
        public ExternalApplicantValidationException(Xeption innerException)
            : base(message: "External applicant validation error occurred, fix the error and try again",
                  innerException)
        { }
    }
}
