using NLog;

namespace Core.Services
{
    /// <summary>
    /// Custom logger service
    /// </summary>
    internal class LoggerService : Logger, ILoggerService
    {
        public new void Trace(string str)
        {
            this.Trace(str);
        }
    }
}

