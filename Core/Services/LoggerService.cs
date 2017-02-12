using System;
using System.Text;
using Core.Emuns;
using Core.Extension;
using Microsoft.Extensions.Logging;

namespace Core.Services
{
    /// <summary>
    /// Custom logger service
    /// </summary>
    internal class LoggerService : ILoggerService
    {
        private readonly ILogger _logger;

        public LoggerService(ILogger logger)
        {
            _logger = logger;
        }

        public LoggerService()
        {

        }

        public event EventHandler<AppendLogArgs> AppendLog;

        public ILogger NLogger
        {
            get
            {
                //if (_logger == null)
                //    _logger = LoggerFactoryExtensions.CreateLogger<LoggerService>();
                return _logger;
            }
        }

        public void Info(string v)
        {
            Console.WriteLine(v);
            AppendLog?.Invoke("LoggerService", new AppendLogArgs(v, ELogType.Info));
        }

        public void Trace(string v)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Info:");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(v.PadLeft(25));
            AppendLog?.Invoke("LoggerService", new AppendLogArgs(v, ELogType.Info));
        }

        public void Error(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

