
using System;
using Microsoft.Extensions.Logging;

namespace Core.Services
{
    public interface ILoggerService
    {
        ILogger NLogger { get; }

        void Info(string v);

        void Warning(string v);

        void Trace(string v);

        void Error(Exception ex);

        event EventHandler<AppendLogArgs> AppendLog;
    }
}
