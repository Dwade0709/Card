using System;

namespace Core.Package
{
    /// <summary>
    /// Full package. Package is container for serialization/deserialization
    /// </summary>
    public interface IBasePackage
    {
        Guid ClientId { get; set; }
    }
}