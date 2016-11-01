using Core.Interfaces;
using ProtoBuf;

namespace Core.Package
{
    [ProtoContract]
    public interface IShortPackage : IBasePackage
    {
        [ProtoMember(1)]
        IParametr Params { get; set; }

        [ProtoMember(2)]
        ICommand Command { get; set; }
    }
}
