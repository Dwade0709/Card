// ReSharper disable once CheckNamespace
namespace Card.Core
{
    internal class RoleCardFactory : CardFactory
    {
        public override Card CreateCard(string name, string description, object weight)
        {
            return new RoleCard() { Description = description, Name = name };
        }
    }
}
