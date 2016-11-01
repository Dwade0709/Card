using Core.Command;
using ProtoBuf;

namespace Core.Package
{
    [ProtoContract]
    public interface ICommandPackage: IBasePackage
    {
        ECommandType? Type { get; set; }
    }
}
