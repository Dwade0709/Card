using System;
using Core;
using Core.Command;
using Core.Interfaces;

namespace Core.Command
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

        public DisconnectCommand(Action<IParametr> command, IParametr param) : base(command, param)
        {
        }

        public DisconnectCommand(Action<IParametr> command) : base(command)
        {
        }
    }
}
