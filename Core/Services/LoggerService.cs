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
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Info:");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(v.PadLeft(25));
            AppendLog?.Invoke("LoggerService", new AppendLogArgs(v, ELogType.Info));
        }

        public void Warning(string v)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Warning:");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(v.PadLeft(25));
            AppendLog?.Invoke("LoggerService", new AppendLogArgs(v, ELogType.Warning));
        }

        public void Trace(string v)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Trace:");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(v.PadLeft(25));
            AppendLog?.Invoke("LoggerService", new AppendLogArgs(v, ELogType.Trace));
        }

        public void Error(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Error:");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(ex.Message.PadLeft(25));
            AppendLog?.Invoke("LoggerService", new AppendLogArgs(ex.Message + ex.StackTrace, ELogType.Exception));
        }
    }
}

