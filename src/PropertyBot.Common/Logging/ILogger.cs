using System;

namespace PropertyBot.Common.Logging
{
    public interface ILogger
    {
        void LogDebug(string message, params object[] args);
        void LogInfo(string message, params object[] args);
        void LogWarning(string message, params object[] args);
        void LogCritical(string message, params object[] args);
        void LogCritical(Exception exception, string message, params object[] args);
    }
}