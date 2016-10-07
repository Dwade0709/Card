using System;
using Core.Interfaces;

namespace Core.Command
{
    /// <summary>
    /// Command class
    /// </summary>
    /// <typeparam name="T">Type parameter</typeparam>
    [Serializable]
    public abstract class ACommand<T> : ICommand where T : class
    {
        private readonly Action<IParametr> _command;
        private IParametr _parametrs;

        /// <summary>
        ///  .ctor
        /// </summary>
        /// <param name="command"></param>
        /// <param name="param"></param>
        protected ACommand(Action<IParametr> command, IParametr param)
        {
            _command = command;
            _parametrs = param;
        }

        protected ACommand(Action<IParametr> command)
        {
            _command = command;
        }


        protected ACommand(IParametr param)
        {
            _parametrs = param;
        }

        /// <summary>
        /// Execute 
        /// </summary>
        public virtual void Execute()
        {
            _command.Invoke(_parametrs);
        }

        public void SetParametr(IParametr parametrs)
        {
            _parametrs = parametrs;
        }
    }
}
