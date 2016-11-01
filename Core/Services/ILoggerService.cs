
using System;
using Microsoft.Extensions.Logging;

namespace Core.Services
{
    public interface ILoggerService
    {
        ILogger NLogger { get; }

        void Trace(string v);
        void Error(Exception ex);
    }
}
