namespace Card.Core
{
    public static class CardFactory
    {
        private class CardFactoryGeneric<TCard> : ICardFactory
        where TCard : ICard, new()
        {
            public ICard CreateCard()
            {
                return new TCard();
            }

        }

        public static ICardFactory GetFactory(string typeName)
        {
            return new CardFactoryGeneric<RoleCard>();
        }
    }
}
