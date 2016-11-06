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
        public ICommand Command { get; set; }
    }
}
