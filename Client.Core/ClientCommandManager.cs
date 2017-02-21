using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Core.Interfaces;
using Core.Services;

namespace Client.Core
{
    internal class ClientCommandManager : ICommandManager
    {
        private readonly Dictionary<string, ICommand> _cacheCommand;

        internal ClientCommandManager()
        {
            _cacheCommand = new Dictionary<string, ICommand>();
        }

        public ICommand GetCommand(string key)
        {
            if (_cacheCommand.ContainsKey(key))
                return _cacheCommand[key];
            throw new NotImplementedException($"COmmand {key} not implemented on the server.");
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
        internal void AddToCacheCommand(string commandName, ICommand command)
        {
            ServiceContainer.Instance.Get<ILoggerService>().Trace($"Append new command {commandName}");
            if (_cacheCommand.ContainsKey(commandName))
                return;
            _cacheCommand.Add(commandName, command);
        }
    }
}
