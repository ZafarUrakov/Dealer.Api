using System;
using System.Threading.Tasks;
using Dealer.Api.Models.Orchestration.Exceptions;
using Dealer.Api.Models.Processings.Exceptions;
using Xeptions;

namespace Dealer.Api.Services.Orchestrations.ExternalApplicants
{
    public partial class OrchestrationService
    {
        private delegate Task ReturningTaskFunction();

        private async Task TryCatch(ReturningTaskFunction returningTaskFunction)
        {
            try
            {
                await returningTaskFunction();
            }
            catch (ExternalApplicantsProcessingValidationException externalApplicantsProcessingValidationException)
            {
                throw CreateAndLogValidationException(
                    externalApplicantsProcessingValidationException.InnerException as Xeption);
            }
        }

        private ExternalApplicantsOrchestrationValidationException CreateAndLogValidationException(Xeption exception)
        {
            var externalApplicantsOrchestrationValidationException =
                new ExternalApplicantsOrchestrationValidationException(exception);

            this.loggingBroker.LogError(externalApplicantsOrchestrationValidationException);

            return externalApplicantsOrchestrationValidationException;
        }
    }
}
