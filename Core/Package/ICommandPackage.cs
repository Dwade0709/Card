using Core.Command;
using Core.Interfaces;
using ProtoBuf;

namespace Core.Package
{
    [ProtoContract]
    public interface ICommandPackage : IBasePackage
    {
        ECommandType? Type { get; set; }

        DynamicParam Params { get; set; }

    }
}
