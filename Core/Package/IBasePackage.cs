using ProtoBuf;
using System;

namespace Core.Package
{
    /// <summary>
    /// Full package. Package is container for serialization/deserialization
    /// </summary>

    [ProtoContract]
    public interface IBasePackage
    {
        [ProtoMember(3)]
        Guid ClientId { get; set; }
    }
}