using Card.Core;
using System;
using System.Collections.Generic;

namespace Game.Core
{
    public interface IGame
    {
        ICardDeck GameRoleDeck { get; set; }

        ICardDeck PlayingDeck { get; }

        ICardDeck RoleCards { get; }

        IList<IPlayer> Players {get;}

    }
}
