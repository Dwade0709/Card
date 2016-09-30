using System;
using Client.Core;
using Core;
using Core.Interfaces;

namespace Server.Core.Command
{
    /// <summary>
    /// Command for send information from server to client
    /// </summary>
    [Serializable]
    internal class PresentServerCommand : ICommand
    {
        private readonly Package _package;

        public PresentServerCommand(Package package)
        {
            _package = package;
        }

        public void Execute()
        {
            var client = ServiceContainer.Instance.Get<IClient>();
            client.Id = _package.ClientId;
            client.ServerInfo = _package.Params as IServerInfoParams;
        }
    }
}
