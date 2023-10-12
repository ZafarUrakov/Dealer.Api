using System.Threading.Tasks;
using Dealer.Api.Brokers.Loggings;
using Dealer.Api.Models.Applicants;
using Dealer.Api.Services.Foundations.Applicants;

namespace Dealer.Api.Services.Processings.Applicants
{
    public class ApplicantProcessingService : IApplicantProcessingService
    {
        private readonly IApplicantService applicantService;
        private readonly ILoggingBroker loggingBroker;

        public ApplicantProcessingService(
            IApplicantService applicantService,
            ILoggingBroker loggingBroker)
        {
            this.applicantService = applicantService;
            this.loggingBroker = loggingBroker;
        }

        public async ValueTask<Applicant> AddApplicantAsync(Applicant applicant)
        {
            return await applicantService.AddApplicantAsync(applicant);
        }
    }
}