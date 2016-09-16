using System;
using NLog;

namespace Core.Services
{
    /// <summary>
    /// Custom logger service
    /// </summary>
    internal class LoggerService : Logger, ILoggerService
    {
        private Logger _logger;

        public Logger NLogger
        {
            get
            {
                if (_logger == null)
                    _logger = LogManager.GetLogger("Parent");
                return _logger;
            }
        }
    }
}

