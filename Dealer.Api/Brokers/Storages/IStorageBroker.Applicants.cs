using System.Linq;
using System.Threading.Tasks;
using System;
using Dealer.Api.Models.Applicants;

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
