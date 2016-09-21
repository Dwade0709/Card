using System;

namespace Core
{
    [Serializable]
    public class Package
    {
        public Guid ClientId;

        public object Params;

        public string Type;

        public string Name;

        public Action Action;
    }
}
