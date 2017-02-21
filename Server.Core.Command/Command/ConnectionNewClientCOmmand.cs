using System;
using System.Linq;
using System.Net.Sockets;
using Core;
using Core.Command;
using Server.Service;
using Core.Package;

namespace Server.Core.Command.Command
{
    internal class ConnectionNewClientCommand : ACommand
    {
        public override void Execute()
        {
            var versionService = ServiceContainer.Instance.Get<IVersionService>();

            var client = ServiceContainer.Instance.Get<AServer>().Clients.SingleOrDefault(p => p.Id == ClientId);

            if (client == null)
                throw new ArgumentException($"Incorrect client ID {ClientId} on package");

            client.Transport<TcpClient>().SendData(versionService.CheckVersion(this.Parametrs.GetValue("clientVersion")).Result
                    ? PackageFactory.GetFactory<ICommandPackage>().Create(ClientId, Guid.NewGuid(), false, false, ECommandType.Disconnect, null)
                    : PackageFactory.GetFactory<ICommandPackage>().Create(ClientId, Guid.NewGuid(), false, false, ECommandType.ConnectionOk, null));
        }

    }
}

