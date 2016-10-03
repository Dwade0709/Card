using System;
using Core.Command;
using Core.Interfaces;

namespace Core
{
    [Serializable]
    public sealed class Package : IFullPackage, IShortPackage
    {
        public Guid ClientId { get; set; }
        public object Params { get; set; }
        public ICommand Command { get; set; }
        public ECommandType? Type { get; set; }
        public string Name { get; set; }
    }
}
