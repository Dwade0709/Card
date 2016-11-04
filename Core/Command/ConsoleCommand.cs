using System;
using Core.Command;
using Core.Interfaces;

namespace Core
{
    public class ConsoleCommand : ACommand
    {
        private readonly IParametr _param;

        public ConsoleCommand(IParametr param) : base(param)
        {
            _param = param;
        }

        public override void Execute()
        {
            Console.WriteLine(_param);
        }

        public void UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}
