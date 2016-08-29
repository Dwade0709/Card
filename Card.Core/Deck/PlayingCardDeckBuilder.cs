using System;

namespace Card.Core
{
    internal class PlayingCardDeckBuilder : DeckBuilder
    {
        public override void CreateCards(CardFactory factory)
        {
            CardDeck.AddCard(factory.CreateCard());
        }

        public override void SetType()
        {
            CardDeck.DeckType = Enum.CardDeckEnum.PLAYING_DECK;
        }
    }
}
