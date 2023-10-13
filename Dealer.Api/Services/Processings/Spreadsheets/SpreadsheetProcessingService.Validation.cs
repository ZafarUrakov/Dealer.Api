using Dealer.Api.Models.ExternalApplicants;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace Dealer.Api.Services.Processings.Spreadsheets
{
    public partial class SpreadsheetProcessingService
    {
        private async ValueTask<List<ExternalApplicant>> ValidateExternalApplicantOnAdd(
            ValueTask<List<ExternalApplicant>> validExteranlApplicants,
            ExternalApplicant externalApplicant)
        {
            Validate(
                (Rule: IsInvalid(externalApplicant.ExternalApplicantId), Parameter: nameof(ExternalApplicant.ExternalApplicantId)),
                (Rule: IsInvalid(externalApplicant.FirstName), Parameter: nameof(ExternalApplicant.FirstName)),
                (Rule: IsInvalid(externalApplicant.LastName), Parameter: nameof(ExternalApplicant.LastName)),
                (Rule: IsInvalid(externalApplicant.Email), Parameter: nameof(ExternalApplicant.Email)),
                (Rule: IsInvalid(externalApplicant.PhoneNumber), Parameter: nameof(ExternalApplicant.PhoneNumber)),
                (Rule: IsInvalid(externalApplicant.BirthDate), Parameter: nameof(ExternalApplicant.BirthDate)),
                (Rule: IsInvalid(externalApplicant.GroupName), Parameter: nameof(ExternalApplicant.GroupName)),
                (Rule: IsInvalid(externalApplicant.GroupId), Parameter: nameof(ExternalApplicant.GroupId)));

            if (invalidApplicantException.Data.Count == 0)
            {
                Console.WriteLine($"{externalApplicant.FirstName} is Validated");

                // Извлечь список из ValueTask
                List<ExternalApplicant> validApplicants = await validExteranlApplicants;

                // Добавить элемент
                validApplicants.Add(externalApplicant);

                // Вернуть обновленный список
                return validApplicants;
            }
            else
            {
                // В случае, если валидация не прошла, просто вернуть исходный список
                return await validExteranlApplicants;
            }
        }


        private dynamic IsInvalid(string text) => new
        {
            Condition = string.IsNullOrWhiteSpace(text),
            Message = "Text is required"
        };

        private dynamic IsInvalid(Guid id) => new
        {
            Condition = id == default,
            Message = "Id is required"
        };

        private dynamic IsInvalid(DateTimeOffset date) => new
        {
            Condition = date == default,
            Message = "Date is required"
        };

        private void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidApplicantException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidApplicantException.ThrowIfContainsErrors();
        }
    }
}
