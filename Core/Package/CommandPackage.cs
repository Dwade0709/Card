using System;
using Core.Command;
using Core.Interfaces;
using ProtoBuf;

namespace Core.Package
{
    [ProtoContract]
    internal class CommandPackage : ICommandPackage
    {
        [ProtoMember(1)]
        public Guid ClientId { get; set; }

        [ProtoMember(2)]
        public ECommandType? Type { get; set; }

        [ProtoMember(3)]
        public IParametr Params { get; set; }
    }
}
