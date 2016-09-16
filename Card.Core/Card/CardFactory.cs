using Card.Core.Card;
using Card.Core.Card.Roles;
using Card.Core.Enum;

namespace Card.Core
{
    public static class CardFactory
    {
        private class CardFactoryGeneric<TCard> : ICardFactory
        where TCard : ICard, new()
        {
            public ICard CreateCard(string name, string description, object weight)
            {
                var obj = new TCard();
                obj.Name = name;
                obj.Weight = weight;
                obj.Description = description;
                return obj;
            }

        }

        public static ICardFactory GetFactory(CardTypeE typeEName)
        {
            switch (typeEName)
            {
                case CardTypeE.RoleCard:
                    return new CardFactoryGeneric<RoleCard>();
                case CardTypeE.GameCard:
                    return new CardFactoryGeneric<GameCard>();
                case CardTypeE.PlayingCard:
                    return new CardFactoryGeneric<PlayingCard>();
                //Role segment
                case CardTypeE.AngelAyes:
                    return new CardFactoryGeneric<AngelAyes>();
                case CardTypeE.BedovayaDjeyn:
                    return new CardFactoryGeneric<BedovayaDjeyn>();
                case CardTypeE.BesheniyPes:
                    return new CardFactoryGeneric<BesheniyPes>();
                case CardTypeE.BigSnake:
                    return new CardFactoryGeneric<BigSnake>();
                case CardTypeE.ButchKesedi:
                    return new CardFactoryGeneric<ButchKesedi>();
                case CardTypeE.Django:
                    return new CardFactoryGeneric<Django>();
                case CardTypeE.DjesiDjeyn:
                    return new CardFactoryGeneric<DjesiDjeyn>();
                case CardTypeE.Djo:
                    return new CardFactoryGeneric<Djo>();
                case CardTypeE.KitKarson:
                    return new CardFactoryGeneric<KitKarson>();
                case CardTypeE.LittleBilly:
                    return new CardFactoryGeneric<LittleBilly>();
                case CardTypeE.LuckyLuk:
                    return new CardFactoryGeneric<LuckyLuk>();
                case CardTypeE.Rozy:
                    return new CardFactoryGeneric<Rozy>();
                case CardTypeE.SuziLafet:
                    return new CardFactoryGeneric<SuziLafet>();
                case CardTypeE.TomKetchup:
                    return new CardFactoryGeneric<TomKetchup>();
                case CardTypeE.Tuko:
                    return new CardFactoryGeneric<Tuko>();
                case CardTypeE.WhithoutName:
                    return new CardFactoryGeneric<WhithoutName>();




                default:
                    return new CardFactoryGeneric<ACard>();
            }

        }
    }
}
