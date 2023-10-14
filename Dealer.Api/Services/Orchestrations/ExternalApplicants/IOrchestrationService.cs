using System.Threading.Tasks;

namespace Dealer.Api.Services.Orchestrations.ExternalApplicants
{
    public interface IOrchestrationService
    {
        Task ProcessImportRequest(string filePath);
    }
}