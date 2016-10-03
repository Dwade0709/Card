using Core.Interfaces;

namespace Server.Core
{
    /// <summary>
/// 
/// </summary>
    public interface ICommandManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        ICommand GetCommand(string key);
    }
}