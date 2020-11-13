using System;
using Microsoft.Extensions.Logging;

namespace PropertyBot.Common.Logging
{
    public class Logger<T> : ILogger
    {
        private readonly ILogger<T> _logger;

        public Logger(ILogger<T> logger)
        {
            _logger = logger;
        }

        public void LogDebug(string message, params object[] args)
        {
            _logger.LogDebug(message, args);
        }

        public void LogInfo(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
        }

        public void LogWarning(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
        }

        public void LogCritical(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
        }

        public void LogCritical(Exception exception, string message, params object[] args)
        {
            _logger.LogInformation(exception, message, args);
        }
    }
}
