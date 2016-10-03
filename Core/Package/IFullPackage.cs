using System;
using Core.Command;

namespace Core.Interfaces
{
    /// <summary>
    /// Full package. Package is container for serialization/deserialization
    /// </summary>
    public interface IFullPackage : IShortPackage, ICommandPackage, IBasePackage
    {
        string Name { get; set; }
    }
}