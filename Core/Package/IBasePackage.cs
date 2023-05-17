using ProtoBuf;
using System;

namespace Core.Package
{
    /// <summary>
    /// Base package. Package is container for serialization/deserialization
    /// </summary>
    [ProtoContract]
    public interface IBasePackage
    {
        /// <summary>
        /// Client ID
        /// </summary>
        Guid ClientId { get; set; }

        /// <summary>
        /// Operation ID
        /// </summary>
        Guid OperationId { get; set; }

        /// <summary>
        /// Is ASYNC Command. Execution ocommand on task TPL
        /// </summary>
        bool IsAsync { get; set; }

        /// <summary>
        /// Awaite result. Actual if ASYNC use
        /// </summary>
        bool IsAwaite { get; set; }
    }
}