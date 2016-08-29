using System;

namespace Card.Core
{
    internal class PlayingCardDeckBuilder : DeckBuilder
    {
        public override void CreateCards()
        {
            throw new NotImplementedException();
        }

        public override void SetType()
        {
            CardDeck.DeckType = Enum.CardDeckEnum.PLAYING_DECK;
        }
    }
}
