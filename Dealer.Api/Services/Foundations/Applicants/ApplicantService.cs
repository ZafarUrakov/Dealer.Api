using System;
using System.Linq;
using System.Threading.Tasks;
using Dealer.Api.Models.Applicants;

namespace Dealer.Api.Services.Foundations.Applicants
{
    public class ApplicantService : IApplicantService
    {
        public ValueTask<Applicant> AddApplicantAsync(Applicant applicant)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Applicant> RetrieveApplicantByIdAsync(Guid applicantid)
        {
            throw new NotImplementedException();
        }

        public IQueryable RetrieveAllApplicants()
        {
            throw new NotImplementedException();
        }

        public ValueTask<Applicant> ModifyApplicantAsync(Applicant applicant)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Applicant> DeleteApplicantAsync(Applicant applicant)
        {
            throw new NotImplementedException();
        }
    }
}