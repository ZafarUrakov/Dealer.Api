using Dealer.Api.Models.ExternalApplicants;
using Dealer.Api.Models.ExternalApplicants.Exceptions;
using System.Collections.Generic;

namespace Dealer.Api.Services.Foundations.ExternalApplicants
{

    public partial class ExternalApplicantService
    {
        InvalidExternalApplicantException invalidExternalApplicantException = new InvalidExternalApplicantException();

        private void ValidateExternalApplicantsOnImport(List<ExternalApplicant> externalApplicants)
        {
            ExternalApplicantNotNull(externalApplicants);
        }

        private List<ExternalApplicant> ExternalApplicantNotNull(List<ExternalApplicant> externalApplicants)
        {
            foreach (var applicant in externalApplicants)
            {
                if (applicant is null)
                {
                    externalApplicants.Remove(applicant);
                    throw new NullExternalApplicantException();
                }
            }

            return externalApplicants;
        }
    }
}
