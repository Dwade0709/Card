using Card.Core;
using System.Collections.Generic;

namespace Game.Core
{
    public interface IGame
    {
        ICardDeck GameRoleDeck { get; }

        ICardDeck PlayingDeck { get; }

        ICardDeck RoleCards { get; }

        IList<IPlayer> Players { get; }

    }
}
