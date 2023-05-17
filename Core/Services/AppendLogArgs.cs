using System;
using Core.Emuns;

namespace Core.Services
{
    public class AppendLogArgs : EventArgs
    {

        public AppendLogArgs(string message, ELogType type)
        {
            Message = message;
            LogType = type;
        }

        public string Message { get; set; }

        public ELogType LogType { get; set; }
    }
}
