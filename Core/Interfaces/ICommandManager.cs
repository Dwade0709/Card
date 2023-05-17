using Core.Interfaces;

namespace Core.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICommandManager
    {
        /// <summary>
        /// Retrun command from cache or create new command
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        ICommand GetCommand(string key);
    }
}