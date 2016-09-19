using System;

namespace Core
{
    [Serializable]
    public class Package
    {
        public object Params { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }

        public Action Action;
    }
}
