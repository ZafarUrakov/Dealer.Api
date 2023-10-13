using Dealer.Api.Models.Applicants;
using System.Linq;
using System.Threading.Tasks;
using System;
using Dealer.Api.Models.Groups;

namespace Dealer.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public async ValueTask<Applicant> InsertApplicantAsync(Applicant applicant) =>
            await InsertAsync(applicant);

        public IQueryable<Applicant> SelectAllApplicants() =>
            SelectAll<Applicant>();

        public async ValueTask<Applicant> SelectApplicantByIdAsync(Guid applicantId) =>
            await SelectAsync<Applicant>(applicantId);

        public async ValueTask<Applicant> UpdateAppolicantAsync(Applicant applicant) =>
            await UpdateAsync(applicant);

        public async ValueTask<Applicant> DeleteApplicantAsync(Applicant applicant) =>
            await DeleteAsync(applicant);
    }
}
