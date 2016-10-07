using System;
using Core.Command;
using Core.Interfaces;

namespace Core
{
    [Serializable]
    public class ConsoleCommand : ACommand<ConsoleCommand>
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
