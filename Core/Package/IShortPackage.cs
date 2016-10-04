using Core.Interfaces;

namespace Core.Package
{
    public interface IShortPackage : IBasePackage
    {
        IParametr<object> Params { get; set; }

        ICommand Command { get; set; }
    }
}
