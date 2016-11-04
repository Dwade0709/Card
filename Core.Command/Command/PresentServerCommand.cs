using System;
using Client.Core;
using Core.Command.Command.Param;
using ProtoBuf;
using ProtoBuf.Meta;
using Core.Interfaces;

namespace Core.Command
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

        public PresentServerCommand() : base()
        {
            //RuntimeTypeModel.Default.Add(typeof(ICommand), true).AddSubType(33, typeof(ACommand)).AddSubType(111, typeof(PresentServerCommand));
        }
    }
}
