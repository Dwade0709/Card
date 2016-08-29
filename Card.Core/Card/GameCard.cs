using System;

namespace Card.Core
{
    internal class GameCard : Card
    {
        public override event Action DoProcess;
    }
}
