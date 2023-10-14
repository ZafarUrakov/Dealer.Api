using System;
using System.Linq;
using System.Threading.Tasks;
using Dealer.Api.Brokers.DateTimes;
using Dealer.Api.Brokers.Loggings;
using Dealer.Api.Brokers.Storages;
using Dealer.Api.Models.Applicants;

namespace Dealer.Api.Services.Foundations.Applicants
{
    public partial class ApplicantService : IApplicantService
    {
        private readonly IStorageBroker storageBroker;
        private readonly IDateTimeBroker dateTimeBroker;
        private readonly ILoggingBroker loggingBroker;

        public ApplicantService(
            IStorageBroker storageBroker,
            IDateTimeBroker dateTimeBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.dateTimeBroker = dateTimeBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<Applicant> AddApplicantAsync(Applicant applicant) =>
        TryCatch(async () =>
        {
            ValidateApplicantOnAdd(applicant);

            return await this.storageBroker.InsertApplicantAsync(applicant);
        });

        public ValueTask<Applicant> RetrieveApplicantByIdAsync(Guid applicantid)
        {
            throw new NotImplementedException();
        }

        public IQueryable RetrieveAllApplicants() =>
             this.storageBroker.SelectAllApplicants();
        

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