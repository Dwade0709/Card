using System;
using System.Collections.Generic;
using Card.Core.Enum;

namespace Card.Core
{
    /// <summary>
    /// It's deck card with randomizer
    /// </summary>
    internal class CardDeck : ICardDeck
    {
        private IList<ICard> _cards;

        protected internal CardDeck()
        {
            if (_cards == null)
                _cards = new List<ICard>();
        }

        public string Name { get; set; }

        public CardDeckEnum DeckType { get; set; }

        public void AddCard(ICard card)
        {
            _cards.Add(card);
        }

        public void RemoveCard(ICard card)
        {
            _cards.Remove(card);
        }

        public ICard GetRandomCard()
        {
            throw new NotImplementedException();
        }
    }
}
