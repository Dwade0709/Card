using System;
using Core.Command;
using Core.Interfaces;
using ProtoBuf;

namespace Core.Package
{
    [ProtoContract]
    internal class Package : IPackage
    {
        [ProtoMember(1)]
        public Guid ClientId { get; set; }

        [ProtoMember(2)]
        public ECommandType? Type { get; set; }

        [ProtoMember(3)]
        public IParametr Params { get; set; }

        [ProtoMember(4)]
        public ICommand Command { get; set; }

        [ProtoMember(5)]
        public string Name { get; set; }
    }
}
