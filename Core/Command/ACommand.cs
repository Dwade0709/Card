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
        private Action<IParametr> _command;
        protected IParametr Parametrs;

        /// <summary>
        ///  .ctor
        /// </summary>
        /// <param name="command"></param>
        /// <param name="param"></param>
        protected ACommand(Action<IParametr> command, IParametr param)
        {
            _command = command;
            Parametrs = param;
        }

        protected ACommand(Action<IParametr> command)
        {
            _command = command;
        }


        protected ACommand(IParametr param)
        {
            Parametrs = param;
        }

        protected ACommand()
        {

        }

        /// <summary>
        /// Execute 
        /// </summary>
        public virtual void Execute()
        {
            _command.Invoke(Parametrs);
        }

        public void SetParametr(IParametr parametrs)
        {
            Parametrs = parametrs;
        }

        public void SetAction(Action<IParametr> command)
        {
            _command = command;
        }
    }
}
