using System;
using Core.Interfaces;

namespace Core
{
    [Serializable]
    public class ConsoleCommand : ICommand
    {
        private readonly string _param;

        public ConsoleCommand(string param)
        {
            _param = param;
        }

        public void Execute()
        {
            Console.WriteLine(_param);
        }

        public void UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}
