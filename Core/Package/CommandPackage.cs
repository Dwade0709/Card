using System;
using System.Runtime.Serialization;
using Core.Command;

namespace Core.Package
{
    [Serializable]
    internal class CommandPackage : ICommandPackage
    {
        public Guid ClientId { get; set; }

        public ECommandType? Type { get; set; }
        
    }
}
