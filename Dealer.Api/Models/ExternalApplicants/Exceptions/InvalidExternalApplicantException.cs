using Xeptions;

namespace Dealer.Api.Models.ExternalApplicants.Exceptions
{
    public class InvalidExternalApplicantException : Xeption
    {
        public InvalidExternalApplicantException()
            : base(message: "External applicant is invalid")
        { }
    }
}
