using System;
using System.Collections.Generic;

namespace Card.Core
{
    public interface ICard
    {
        string Name { get; set; }

        string Description { get; set; }

        object Weight { get; set; }

        event Action StartProcess;

        event Action DoProcess;

        event Action EndProcess;

        IList<Action> AddOperation(object data);
    }
}
