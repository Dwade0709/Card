using System;
using Core.Command;
using Core.Helper;
using Core.Interfaces;

namespace Core
{
    /// <summary>
    /// Command class
    /// </summary>
    /// <typeparam name="T">Type parameter</typeparam>
    [Serializable]
    public class Command<T> : ICommand
    {
        private readonly T _target;
        private readonly Action<T> _command;

        /// <summary>
        ///  
        /// </summary>
        /// <param name="target"></param>
        /// <param name="command"></param>
        public Command(T target)
        {
            _target = target;
            // _command = command;
        }

        public Command()
        {

        }

        /// <summary>
        /// Execute 
        /// </summary>
        public void Execute()
        {
            if (_target is ECommandType)
            {
                switch ((ECommandType)((object)_target))
                {
                    case ECommandType.Disconnect:
                        break;
                    default:
                        break;
                }
            }
            _command(_target);
        }
    }
}
