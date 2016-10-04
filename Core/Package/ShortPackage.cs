using System;
using Core.Interfaces;

namespace Core.Package
{
    [Serializable]
    internal class ShortPackage : IShortPackage
    {
        public Guid ClientId { get; set; }

        public ICommand Command { get; set; }

        public IParametr<object> Params { get; set; }
    }
}
