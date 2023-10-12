using System.Threading.Tasks;
using Dealer.Api.Models.Applicants;

namespace Dealer.Api.Services.Processings.Applicants
{
    public interface IApplicantProcessingService
    {
        ValueTask<Applicant> AddApplicantAsync(Applicant applicant);
    }
}