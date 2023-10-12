using System;
using System.Linq;
using System.Threading.Tasks;
using Dealer.Api.Models.Applicants;

namespace Dealer.Api.Services.Foundations.Applicants
{
    public interface IApplicantService
    {
        ValueTask<Applicant> AddApplicantAsync(Applicant applicant);
        ValueTask<Applicant> RetrieveApplicantByIdAsync(Guid applicantid);
        IQueryable RetrieveAllApplicants();
        ValueTask<Applicant> ModifyApplicantAsync(Applicant applicant);
        ValueTask<Applicant> DeleteApplicantAsync(Applicant applicant);
    }
}