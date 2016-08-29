﻿using Card.Core.Enum;
using System.Collections.Generic;

namespace Card.Core
{
    public interface ICardGame
    {
        void Init();

        IList<ICardDeck> CardsDecks { get; }

        ICard PassCards(CardDeckEnum cardDesc);
    }
}
