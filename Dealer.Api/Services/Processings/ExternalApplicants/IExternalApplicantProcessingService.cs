using Dealer.Api.Models.ExternalApplicants;
using System.Collections.Generic;
using System.IO;

namespace Dealer.Api.Services.Processings.ExternalApplicants
{
    public interface IExternalApplicantProcessingService
    {
        List<ExternalApplicant> GetValidExternalApplicants(MemoryStream memoryStream);
    }
}