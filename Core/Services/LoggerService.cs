using System;
using Microsoft.Extensions.Logging;

namespace Core.Services
{
    /// <summary>
    /// Custom logger service
    /// </summary>
    internal class LoggerService : ILoggerService
    {
        private ILogger _logger;

        public ILogger NLogger
        {
            get
            {
                //if (_logger == null)
                //    _logger = LoggerFactoryExtensions.CreateLogger<LoggerService>();
                return _logger;
            }
        }

        public void Trace(string v)
        {
            //throw new NotImplementedException();
            Console.WriteLine(v);
        }

        public void Error(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }


    }
}

