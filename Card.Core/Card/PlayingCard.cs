using System;

namespace Card.Core
{
    internal class PlayingCard : Card
    {
        public override event Action DoProcess;
    }
}
