using System;
using Core.Command;

namespace Core.Interfaces
{
    public interface ICommandPackage: IBasePackage
    {
        ECommandType? Type { get; set; }
    }
}
