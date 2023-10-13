using Dealer.Api.Models.ExternalApplicants;
using System.Collections.Generic;
using System.IO;

namespace Dealer.Api.Services.Foundations.ExternalApplicants
{
    public interface IExternalApplicantService
    {
        List<ExternalApplicant> ReadExternalApplicants(MemoryStream memoryStream);
    }
}