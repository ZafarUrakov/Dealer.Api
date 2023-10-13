using Dealer.Api.Models.ExternalApplicants.Exceptions;
using System;

namespace Dealer.Api.Brokers.Loggings
{
    public interface ILoggingBroker
    {
        void LogError(Exception exception);
        void LogCritical(Exception exception);
    }
}