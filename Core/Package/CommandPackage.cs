using System;
using Core.Command;
using ProtoBuf;

namespace Core.Package
{
    [ProtoContract]
    internal class CommandPackage : ICommandPackage
    {
        [ProtoMember(1)]
        public Guid ClientId { get; set; }

        [ProtoMember(6)]
        public Guid OperationId { get; set; }

        [ProtoMember(2)]
        public ECommandType Type { get; set; }

        [ProtoMember(3)]
        public DynamicParam Params { get; set; }

        [ProtoMember(4)]
        public bool IsAsync { get; set; }

        [ProtoMember(5)]
        public bool IsAwaite { get; set; }
    }
}
