using System;
using Client.Core;
using Core;
using Core.Command;
using Core.Command.Command;
using Core.Command.Command.Param;
using Core.Interfaces;
using Game.Interfaces;

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
                GlobalFacade.LoggerService.NLogger.Trace("Init services");
                ServiceContainer.Instance.SetAs<IRandomizer>("Core.Randomizer");
                ServiceContainer.Instance.SetAs<IGamePublic>("Game.Service.GamePublic", "Game.Service");
                ServiceContainer.Instance.SetAs<IPlayerService>("Game.Service.PlayerService", "Game.Service");
                ServiceContainer.Instance.SetAs<IUserService>("Game.Service.UserService", "Game.Service");
                ServiceContainer.Instance.SetAs<IClient>("Client.TCP.ClientTcp", "Client.TCP");

                GlobalFacade.LoggerService.NLogger.Trace("Command manager init");
                ServiceContainer.Instance.SetAs<ICommandManager>(CommandManager.Instance);

                ServiceContainer.Instance.SetAs<ServerInfoParam>(new ServerInfoParam(true));
                CommandManager.Instance.AddToCacheCommand("PresentServerCommand", CommandFactory<PresentServerCommand>.GetFactory().Create());
            }
            catch (Exception ex)
            {
                GlobalFacade.LoggerService.NLogger.Error(ex);
            }
        }
    }
}
