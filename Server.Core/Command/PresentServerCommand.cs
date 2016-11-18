using System;
using Client.Core;
using Core;
using Core.Command;
using ProtoBuf;
using Serer.Core.Param;

namespace Server.Core.Command
{
    /// <summary>
    /// Command for send information from server to client
    /// </summary>
    [ProtoContract]

    public class PresentServerCommand : ACommand
    {
        public override void Execute()
        {
            var client = ServiceContainer.Instance.Get<IClient>();
            client.Id = Parametrs.GetValue<Guid>("ClientGuid");
            client.ServerInfo = new ServerInfoParam(Parametrs.GetValue<string>("ServerAdress"), Parametrs.GetValue<string>("ServerVersion"));
        }
    }
}
