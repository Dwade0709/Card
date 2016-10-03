using System;
using Core;
using Core.Interfaces;

namespace Server.Core.Command
{
    internal class DisconnectCommand : ICommand
    {
        private readonly Guid _id;

        public DisconnectCommand(Guid id)
        {
            _id = id;
        }

        public void Execute()
        {
            var server = ServiceContainer.Instance.Get<AServer>();
            server.RemoveConnection(_id);
        }
    }
}
