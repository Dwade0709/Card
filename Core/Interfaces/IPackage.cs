using System;
using Core.Command;

namespace Core.Interfaces
{
    public interface IFullPackage:IShortPackage
    {
        ECommandType? Type { get; set; }

        string Name { get; set; }
    }

    public interface IShortPackage
    {
        Guid ClientId { get; set; }

        object Params { get; set; }

        ICommand Command { get; set; }
    }
}