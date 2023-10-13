using Xeptions;

namespace Dealer.Api.Models.Processings.Exceptions
{
    public class ExternalApplicantsProcessingValidationException : Xeption
    {
        public ExternalApplicantsProcessingValidationException(Xeption innerException)
            : base(message: "External applicant validation error occurred fix the error and try again",
                  innerException)
        { }
    }
}
