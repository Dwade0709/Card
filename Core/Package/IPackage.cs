using Core.Interfaces;
using ProtoBuf;

namespace Core.Package
{
    /// <summary>
    /// Full package. Package is container for serialization/deserialization
    /// </summary>
    [ProtoContract]
    public interface IPackage : IShortPackage, ICommandPackage, IBasePackage
    {
        string Name { get; set; }
    }
}