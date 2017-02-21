using System;
using Core.Command;
using Core.Interfaces;

namespace Server.Core.Command
{
    [ProtoBuf.ProtoContract]
    public class DisconnectCommand : ACommand
    {
        private readonly Guid _id;



        public void Execute()
        {
            //var server = ServiceContainer.Instance.Get<AServer>();
            //server.RemoveConnection(_id);
        }

        public DisconnectCommand(Guid clientId, Action<IParametr> command, IParametr param) : base(clientId, command, param)
        {
        }

        public DisconnectCommand(Guid clientId, Action<IParametr> command) : base(clientId, command)
        {
        }
    }
}
