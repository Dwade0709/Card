using System;
using System.Linq;
using System.Reflection;
using Client.Core;
using Core;
using Core.Command;
using Core.Interfaces;
using Game.Interfaces;
using Serer.Core.Param;
using Server.Core.Command;

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
                GlobalFacade.LoggerService.Trace("Init services");
                ServiceContainer.Instance.SetAs<IRandomizer>("Core.Randomizer");
                ServiceContainer.Instance.SetAs<IGamePublic>("Game.Service.GamePublic", "Game.Service");
                ServiceContainer.Instance.SetAs<IPlayerService>("Game.Service.PlayerService", "Game.Service");
                ServiceContainer.Instance.SetAs<IUserService>("Game.Service.UserService", "Game.Service");
                ServiceContainer.Instance.SetAs<IClient>("Client.TCP.ClientTcp", "Client.Core");

                GlobalFacade.LoggerService.Trace("Command manager init");

                ServiceContainer.Instance.SetAs<ICommandManager>(CommandManager.Instance);

                ServiceContainer.Instance.SetAs<ServerInfoParam>(new ServerInfoParam(true));

                CommandManager.Instance.AddToCacheCommand("PresentServerCommand", CommandFactory<PresentServerCommand>.GetFactory().Create());

                var assembly = Assembly.Load(new AssemblyName("Core.Command"));
                foreach (var ecommand in Enum.GetNames(typeof(ECommandType)))
                {
                    GlobalFacade.LoggerService.Trace($"Try find command {ecommand}");
                    var command = assembly.GetType($"Core.Command.Command.{ecommand}Command");
                    if (command != null)
                        CommandManager.Instance.AddToCacheCommand(ecommand, (ICommand)command.GetTypeInfo().GetConstructors()[0].Invoke(null));
                    else
                        GlobalFacade.LoggerService.Trace($"Command {ecommand} not implemented");
                }

            }
            catch (Exception ex)
            {
                GlobalFacade.LoggerService.Error(ex);
            }
        }
    }
}
