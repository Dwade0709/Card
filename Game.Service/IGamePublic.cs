using Card.Core;
using Game.Core;
using System;

namespace Game.Interfaces
{
    public interface IGamePublic
    {
        IObservable<IPlayer> Players { get; set; }

        ICardDeck GameDeck { get; }

    }
}
