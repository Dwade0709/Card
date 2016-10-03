using System;
using Core.Command;
using Core.Interfaces;

namespace Core
{
    internal class CommandPackage : ICommandPackage
    {
        public Guid ClientId { get; set; }

        public ECommandType? Type { get; set; }
    }
}
