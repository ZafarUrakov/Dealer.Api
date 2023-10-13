using Dealer.Api.Models.Applicants;
using Dealer.Api.Models.Applicants.Exceptions;
using System;
using System.Data;
using System.Reflection.Metadata;

namespace Dealer.Api.Services.Foundations.Applicants
{
    public partial class ApplicantService
    {
        private void ValidateApplicantOnAdd(Applicant applicant)
        {
            ValidateApplicantNotNull(applicant);

            Validate(
                (Rule: IsInvalid(applicant.ApplicantId), Parameter: nameof(Applicant.ApplicantId)),
                (Rule: IsInvalid(applicant.FirstName), Parameter: nameof(Applicant.FirstName)),
                (Rule: IsInvalid(applicant.LastName), Parameter: nameof(Applicant.LastName)),
                (Rule: IsInvalid(applicant.Email), Parameter: nameof(Applicant.Email)),
                (Rule: IsInvalid(applicant.BirthDate), Parameter: nameof(Applicant.BirthDate)),
                (Rule: IsInvalid(applicant.PhoneNumber), Parameter: nameof(Applicant.PhoneNumber)));
        }

        private static dynamic IsInvalid(Guid applicantId) => new
        {
            Condition = applicantId == default,
            Message = "Id is required"
        };

        private static dynamic IsInvalid(string text) => new
        {

            Condition = System.String.IsNullOrWhiteSpace(text),
            Message = "Text is required"
        };

        private static dynamic IsInvalid(DateTimeOffset date) => new
        {
            Condition = date == default,
            Message = "Date is required"
        };

        private static void ValidateApplicantNotNull(Applicant applicant)
        {
            if (applicant == null)
            {
                throw new NullApplicantExeption();
            }
        }
        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidClientException = new InvalidApplicantException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidClientException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidClientException.ThrowIfContainsErrors();
        }
    }
}
