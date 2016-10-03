using System;

namespace Core.Interfaces
{
    public interface IShortPackage : IBasePackage
    {
        IParametr<object> Params { get; set; }

        ICommand Command { get; set; }
    }
}
