using System;

namespace Card.Core
{
    internal class RoleCardDeckBuilder : DeckBuilder
    {
        public override void CreateCards()
        {
            throw new NotImplementedException();
        }

        public override void SetType()
        {
            CardDeck.DeckType = Enum.CardDeckEnum.ROLE_DECK;
        }
    }
}
