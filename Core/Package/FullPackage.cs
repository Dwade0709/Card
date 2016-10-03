using System;
using Core.Command;
using Core.Interfaces;

namespace Core
{
    internal class FullPackage : IFullPackage
    {
        public Guid ClientId { get; set; }

        public ECommandType? Type { get; set; }

        public IParametr<object> Params { get; set; }

        public ICommand Command { get; set; }

        public string Name { get; set; }
    }
}
