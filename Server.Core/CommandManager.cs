using System.Collections.Generic;
using Core;
using Core.Interfaces;

namespace Server.Core
{
    /// <summary>
    /// Singletone command manager for caching command
    /// </summary>
    internal class CommandManager : Singleton<CommandManager>, ICommandManager
    {
        private readonly Dictionary<string, ICommand> _cacheCommand;

        private CommandManager()
        {
            _cacheCommand = new Dictionary<string, ICommand>();
        }

        public ICommand GetCommand(string key)
        {
            if (_cacheCommand.ContainsKey(key))
                return _cacheCommand[key];


            var command = CommandFactory.GetFactory<ICommand>().Create<ICommand>();
            return command;
        }


        /// <summary>
        /// Pre init commands
        /// </summary>
        internal void PreInitCommands()
        {

        }

        /// <summary>
        /// Add to cache command
        /// </summary>
        internal void AddToCacheCommand()
        {
            
        }
    }
}
