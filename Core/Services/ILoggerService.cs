using NLog;


namespace Core.Services
{
    public interface ILoggerService
    {
        Logger NLogger { get; }
    }
}
