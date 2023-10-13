using Xeptions;

namespace Dealer.Api.Models.Applicants.Exceptions
{
    public class NullApplicantExeption : Xeption
    {
        public NullApplicantExeption()
            : base(message: "Applicant is null.")
        { }
    }
}
