using CardsTable.Settings;
using VContainer;
using VContainer.Unity;

namespace CardsTable.CardDeck
{
    public class CardDeckFactory
    {
        private readonly CardDeckSettings deckSettings;
        private readonly LifetimeScope lifetimeScope;

        public CardDeckFactory(CardDeckSettings deckSettings, LifetimeScope lifetimeScope)
        {
            this.deckSettings = deckSettings;
            this.lifetimeScope = lifetimeScope;
        }

        public CardDeckModel Create()
        {
            var context = lifetimeScope.CreateChildFromPrefab(deckSettings.CardDeckPrefab);
            return context.Container.Resolve<CardDeckModel>();
        }
    }
}