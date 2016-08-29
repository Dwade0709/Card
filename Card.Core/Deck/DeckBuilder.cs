﻿namespace Card.Core
{
    /// <summary>
    /// Builder abstract for creating Card Deck
    /// </summary>
    abstract class DeckBuilder
    {
        public ICardDeck CardDeck;

        public DeckBuilder()
        {
            CardDeck = new CardDeck();
            SetType();
        }

        public abstract void SetType();

        public abstract void CreateCards(CardFactory factory);
    }
}
