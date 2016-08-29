// ReSharper disable once CheckNamespace
namespace Card.Core
{
    internal class GameCardFactory : CardFactory
    {
        public override Card CreateCard(string name, string description, object weight)
        {
            return new GameCard() { Description = description, Name = name };
        }
    }
}
