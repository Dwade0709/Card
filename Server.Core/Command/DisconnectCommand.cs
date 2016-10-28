using System;
using Core;
using Core.Command;
using Core.Interfaces;

namespace Server.Core.Command
{
    internal class DisconnectCommand : ACommand<DisconnectCommand>
    {
        private readonly Guid _id;



        public void Execute()
        {
            var server = ServiceContainer.Instance.Get<AServer>();
            server.RemoveConnection(_id);
        }

        public void SetParametr(IParametr parametrs)
        {
            throw new NotImplementedException();
        }

        public DisconnectCommand(Action<IParametr> command, IParametr param) : base(command, param)
        {
        }

        public DisconnectCommand(Action<IParametr> command) : base(command)
        {
        }
    }
}
