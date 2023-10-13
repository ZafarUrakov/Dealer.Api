using System.Collections.Generic;
using System.IO;
using Dealer.Api.Models.ExternalApplicants;

namespace Dealer.Api.Services.Processings.ExternalApplicants
{
    public interface IExternalApplicantProcessingService
    {
        List<ExternalApplicant> GetValidExternalApplicants(string failPath);
    }
}