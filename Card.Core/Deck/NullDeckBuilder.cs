using System;

namespace Card.Core
{
    internal class NullDeckBuilder : DeckBuilder
    {
        public override void CreateCards(ICardFactory factory)
        {
            throw new NotImplementedException();
        }

        public override void SetName()
        {
            throw new NotImplementedException();
        }

        public override void SetType()
        {
            throw new NotImplementedException();
        }
    }
}
