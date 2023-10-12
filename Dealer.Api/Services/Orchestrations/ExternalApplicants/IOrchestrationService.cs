using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Dealer.Api.Services.Orchestrations.ExternalApplicants
{
    public interface IOrchestrationService
    {
        Task ProcessImportRequest(IFormFile formFile);
    }
}