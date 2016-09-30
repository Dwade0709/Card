using System;
using Client.Core;
using Core;
using Core.Interfaces;
using Core.Services;
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
                ServiceContainer.Instance.SetAs<ILoggerService>("Core.Services.LoggerService");
                ServiceContainer.Instance.SetAs<IRandomizer>("Core.Randomizer");
                ServiceContainer.Instance.SetAs<IGamePublic>("Game.Service.GamePublic", "Game.Service");
                ServiceContainer.Instance.SetAs<IPlayerService>("Game.Service.PlayerService", "Game.Service");
                ServiceContainer.Instance.SetAs<IUserService>("Game.Service.UserService", "Game.Service");
                ServiceContainer.Instance.SetAs<IClient>("Client.TCP.ClientTcp", "Client.TCP");

                ServiceContainer.Instance.SetAs<ServerInfo>(new ServerInfo());
            }
            catch (Exception ex)
            {

            }
        }
    }
}
