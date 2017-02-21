using System;
using ProtoBuf;

namespace Core.Interfaces
{
    /// <summary>
    /// Interface for command. All 
    /// </summary>
    [ProtoContract]
    public interface ICommand
    {
        /// <summary>
        /// Executor for implemented command
        /// </summary>
        void Execute();

        /// <summary>
        /// Set parametrs to 
        /// </summary>
        /// <param name="parametrs"></param>
        void SetParametr(IParametr parametrs);

        /// <summary>
        /// Client idintificator for call back
        /// </summary>
        Guid ClientId { get; set; }
    }
}
