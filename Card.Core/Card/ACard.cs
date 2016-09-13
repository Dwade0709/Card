using System;
using System.Collections.Generic;

namespace Card.Core
{
    internal class ACard : ICard
    {
        public string Description { get; set; }

        public string Name { get; set; }

        public object Weight { get; set; }

        public event Action DoProcess;
        public event Action EndProcess;
        public event Action StartProcess;

        public IList<Action> AddOperation(object data)
        {
            throw new NotImplementedException();
        }
    }
}
