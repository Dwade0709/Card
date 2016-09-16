using NLog;


namespace Core.Services
{
    public interface ILoggerService:ILogger
    {
        new void Trace(string str);
    }
}
