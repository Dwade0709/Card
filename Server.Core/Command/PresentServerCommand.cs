using System;
using Client.Core;
using Core;
using Core.Command;
using Core.Interfaces;

namespace Server.Core.Command
{
    /// <summary>
    /// Command for send information from server to client
    /// </summary>
    [Serializable]
    internal class PresentServerCommand : ACommand<PresentServerCommand>
    {
        private IParametr parametr;

        public override void Execute()
        {
            var client = ServiceContainer.Instance.Get<IClient>();
            //client.Id = _package.ClientId;
            //client.ServerInfo = _package.Params as IServerInfoParams;
        }

        public PresentServerCommand(Action<IParametr> command, IParametr param) : base(command, param)
        {
        }

        public PresentServerCommand(Action<IParametr> command) : base(command)
        {
        }

        public PresentServerCommand(IParametr parametr) : base(parametr)
        {
            this.parametr = parametr;
        }
    }
}
