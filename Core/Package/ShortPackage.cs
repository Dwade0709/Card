using System;
using Core.Interfaces;
using ProtoBuf;

namespace Core.Package
{
    [ProtoContract]
    internal class ShortPackage : IShortPackage
    {
        [ProtoMember(1)]
        public Guid ClientId { get; set; }

        [ProtoMember(2)]
        public Guid OperationId { get; set; }

        [ProtoMember(3)]
        public bool IsAsync { get; set; }

        [ProtoMember(4)]
        public bool IsAwaite { get; set; }

        [ProtoMember(5)]
        public ICommand Command { get; set; }
    }
}
