using System;

namespace Dealer.Api.Brokers.Loggings
{
    public interface ILoggingBroker
    {
        public void LogCritical(Exception exception);
        public void LogError(Exception exception);
    }
}