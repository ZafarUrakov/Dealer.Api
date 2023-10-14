using Dealer.Api.Models.Applicants;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Dealer.Api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Applicant> InsertApplicantAsync(Applicant applicant);
        IQueryable<Applicant> SelectAllApplicants();
        ValueTask<Applicant> SelectApplicantByIdAsync(Guid applicantId);
        ValueTask<Applicant> UpdateAppolicantAsync(Applicant applicant);
        ValueTask<Applicant> DeleteApplicantAsync(Applicant applicant);
    }
}
