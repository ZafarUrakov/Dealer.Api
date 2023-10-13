using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using Dealer.Api.Models.ExternalApplicants;
using Dealer.Api.Models.ExternalApplicants.Exceptions;

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
                if(applicant is null)
                {
                    externalApplicants.Remove(applicant);
                    throw new NullExternalApplicantException();
                }
            }

            return externalApplicants;
        }
    }
}
