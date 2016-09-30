using System;
using Core.Interfaces;

namespace Core
{
    [Serializable]
    public class Package
    {
        public Guid ClientId;

        public object Params;

        public string Type;

        public string Name;

        public ICommand Command;
    }
}
