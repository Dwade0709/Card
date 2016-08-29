using System;

namespace Card.Core
{
    internal abstract class Card : ICard
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Weight { get; set; }

        public abstract event Action DoProcess;
    }
}
