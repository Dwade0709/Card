using System;

// ReSharper disable once CheckNamespace
namespace Card.Core
{
    internal class PlayingCard : Card
    {
        public override event Action DoProcess;
    }
}
