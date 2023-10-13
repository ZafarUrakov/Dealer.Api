using Xeptions;

namespace Dealer.Api.Models.Applicants.Exceptions
{
    public class InvalidApplicantException : Xeption
    {
        public InvalidApplicantException()
            : base(message: "Applicant is invalid.")
        { }
    }
}
