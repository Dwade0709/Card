using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Client.Core;
using Core;
using Core.Command;
using Core.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Server.Core
{
    public sealed class Initialazer : Singleton<Initialazer>
    {
        /// <summary>
        /// Private constructor for singletone
        /// </summary>
        private Initialazer() { }

        public void InitServices()
        {
            try
            {
                GlobalFacade.LoggerService.Trace("+=============================+");
                GlobalFacade.LoggerService.Trace($"Server Version {Assembly.GetEntryAssembly().GetName().Version}");
                GlobalFacade.LoggerService.Trace("+=============================+");
                GlobalFacade.LoggerService.Trace("Init services");
                var builder = new ConfigurationBuilder();
                builder.SetBasePath(Directory.GetCurrentDirectory());
                builder.AddJsonFile("project.json");
                var configuration = builder.Build();
                GlobalFacade.Settings = new ServerSettings
                {
                    ServerVersion = Assembly.GetEntryAssembly().GetName().Version.ToString(),
                    ServerIp = configuration["settings:serverIp"],
                    ServerPort = configuration["settings:serverPort"],
                    IsChatEnable = Convert.ToBoolean(configuration["settings:IsChatEnabled"]),
                    AccountsDbConnection = configuration["settings:accountsDB"],
                    ServerSettingDbConnection = configuration["settings:settingsDB"]
                };

                ServiceContainer.Instance.SetAs<IRandomizer>("Core.Randomizer");
                ServiceContainer.Instance.SetAs<IClient>("Client.TCP.ClientTcp", "Client.Core");
                //ServiceContainer.Instance.SetAs<IGamePublic>("Game.Service.GamePublic", "Game.Service");
                //ServiceContainer.Instance.SetAs<IPlayerService>("Game.Service.PlayerService", "Game.Service");
                //ServiceContainer.Instance.SetAs<IUserService>("Game.Service.UserService", "Game.Service");

                GlobalFacade.LoggerService.Trace("Command manager init");
                ServiceContainer.Instance.SetAs<ICommandManager>(CommandManager.Instance);

                var assembly = Assembly.Load(new AssemblyName("Server.Core.Command"));
                foreach (var ecommand in Enum.GetNames(typeof(ECommandType)))
                {
                    GlobalFacade.LoggerService.Trace($"Try find command {ecommand}");
                    var command = assembly.GetType($"Server.Core.Command.Command.{ecommand}Command");
                    if (command != null)
                        CommandManager.Instance.AddToCacheCommand(ecommand, (ICommand)command.GetTypeInfo().GetConstructors()[0].Invoke(null));
                    else
                        GlobalFacade.LoggerService.Trace($"Command {ecommand} not implemented");
                }

                
                //ServiceContainer.Instance.SetAs(serviceAssembly.GetType("Server.Service.IUserService"), serviceAssembly.GetType("Server.Service.Implementation.UserService").GetConstructors()[0].Invoke(null));
                GlobalFacade.LoggerService.Trace("Init services");
                var serviceAssembly = Assembly.Load(new AssemblyName("Server.Service"));
                ServiceContainer.Instance.SetAs(serviceAssembly.GetType("Server.Service.IUserService"), serviceAssembly.GetType("Server.Service.Implementation.UserService").GetConstructors()[0].Invoke(null));
                ServiceContainer.Instance.SetAs(serviceAssembly.GetType("Server.Service.IServerSetting"), serviceAssembly.GetType("Server.Service.Implementation.ServerSetting").GetConstructors()[0].Invoke(null));
                ServiceContainer.Instance.SetAs(serviceAssembly.GetType("Server.Service.IVersionService"), serviceAssembly.GetType("Server.Service.Implementation.VersionService").GetConstructors()[0].Invoke(null));

            }
            catch (Exception ex)
            {
                GlobalFacade.LoggerService.Error(ex);
            }
        }
    }
}
