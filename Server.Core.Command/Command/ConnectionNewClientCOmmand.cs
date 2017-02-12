using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Core.Command;
using Server.Service;

namespace Server.Core.Command.Command
{
    internal class ConnectionNewClientCommand : ACommand
    {
        public override void Execute()
        {
            ServiceContainer.Instance.Get<IVersionService>();


        }

    }
}
