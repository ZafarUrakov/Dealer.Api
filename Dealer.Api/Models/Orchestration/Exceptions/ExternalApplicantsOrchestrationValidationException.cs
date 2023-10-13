using Xeptions;

namespace Dealer.Api.Models.Orchestration.Exceptions
{
    public class ExternalApplicantsOrchestrationValidationException : Xeption
    {
        public ExternalApplicantsOrchestrationValidationException(Xeption innerException)
            : base(message: "External applicant validation error occurred, fix the error and try again",
                  innerException)
        { }
    }
}
