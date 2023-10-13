using Xeptions;

namespace Dealer.Api.Models.ExternalApplicants.Exceptions
{
    public class NullExternalApplicantException : Xeption
    {
        public NullExternalApplicantException()
            : base(message:"External applicant is null")
        { }
    }
}
