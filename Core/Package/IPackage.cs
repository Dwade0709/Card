using Core.Interfaces;

namespace Core.Package
{
    /// <summary>
    /// Full package. Package is container for serialization/deserialization
    /// </summary>
    public interface IPackage : IShortPackage, ICommandPackage, IBasePackage
    {
        string Name { get; set; }
    }
}