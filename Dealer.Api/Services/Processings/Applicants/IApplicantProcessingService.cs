using Dealer.Api.Models.Applicants;
using System.Threading.Tasks;

namespace Dealer.Api.Services.Processings.Applicants
{
    public interface IApplicantProcessingService
    {
        ValueTask<Applicant> AddApplicantAsync(Applicant applicant);
    }
}