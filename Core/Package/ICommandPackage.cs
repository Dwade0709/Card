using Core.Command;

namespace Core.Package
{
    public interface ICommandPackage: IBasePackage
    {
        ECommandType? Type { get; set; }
    }
}
