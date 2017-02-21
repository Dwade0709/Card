using System.Reflection;
using Core;
using Core.Command;
using Core.Interfaces;
using Core.Services;

namespace Client.Core
{
    public static class ClientInitializer
    {
        public static ILoggerService LoggerService;

        public static void Initialaze()
        {
            var commandManager = new ClientCommandManager();
            ServiceContainer.Instance.SetAs<ILoggerService>("Core.Services.LoggerService");
            LoggerService = ServiceContainer.Instance.Get<ILoggerService>();
            ServiceContainer.Instance.SetAs<ICommandManager>(commandManager);
            ServiceContainer.Instance.SetAs<IInformService>(new BaseInfoService());


            var assembly = Assembly.Load(new AssemblyName("Client.Core.Command"));
            foreach (var type in assembly.GetTypes())
            {
                LoggerService.Trace($"Check {type.FullName}");

                if (type as ICommand != null)
                    commandManager.AddToCacheCommand(type.Name, (ICommand)type.GetTypeInfo().GetConstructors()[0].Invoke(null));
                else
                    continue;
            }

        }
    }
}
