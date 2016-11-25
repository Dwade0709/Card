using Core;
using Core.Services;

namespace Server.Core
{
    public static class GlobalFacade
    {
        public static ILoggerService LoggerService
        {
            get
            {
                var logger = ServiceContainer.Instance.Get<ILoggerService>();
                if (logger == null)
                {
                    ServiceContainer.Instance.SetAs<ILoggerService>("Core.Services.LoggerService");
                    logger = ServiceContainer.Instance.Get<ILoggerService>();
                }
                return logger;
            }
        }

        public static ServerSettings Settings { get; set; }

    }
}
