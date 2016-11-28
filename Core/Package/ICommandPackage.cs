using Core.Command;
using ProtoBuf;

namespace Core.Package
{
    /// <summary>
    /// COmmand package. It's universal package with parametr and command must be on cache
    /// </summary>
    [ProtoContract]
    public interface ICommandPackage : IBasePackage
    {
        /// <summary>
        /// Type of command
        /// </summary>
        ECommandType Type { get; set; }

        /// <summary>
        /// Dynamoc parametr for command
        /// </summary>
        DynamicParam Params { get; set; }
    }
}
