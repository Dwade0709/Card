using System;
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
            }
            catch (Exception ex)
            {
                GlobalFacade.LoggerService.Error(ex);
            }
        }
    }
}
