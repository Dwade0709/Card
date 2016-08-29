using System;

namespace Card.Core
{
    public interface ICard
    {
        string Name { get; set; }

        string Description { get; set; }

        int Weight { get; set; }

        event Action DoProcess;
    }
}
