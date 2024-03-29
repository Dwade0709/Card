﻿using System;
using System.Collections.Generic;
using Card.Core.Enum;

// ReSharper disable once CheckNamespace
namespace Card.Core
{
    /// <summary>
    /// It's deck card with randomizer
    /// </summary>
    internal class CardDeck : ICardDeck
    {
        private readonly IList<ICard> _cards;

        private readonly IList<ICard> _removedCards;

        internal CardDeck()
        {
            _cards = new List<ICard>();
            _removedCards = new List<ICard>();
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

        public IList<ICard> Cards()
        {
            return _cards;
        }

        public IList<ICard> RemovedCards()
        {
            return _removedCards;
        }
    }
}
