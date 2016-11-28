using Core.Interfaces;
using ProtoBuf;

namespace Core.Package
{
    //Short package with command only. Command parametr will be on command
    [ProtoContract]
    public interface IShortPackage : IBasePackage
    {
        [ProtoMember(2)]
        ICommand Command { get; set; }
    }
}
