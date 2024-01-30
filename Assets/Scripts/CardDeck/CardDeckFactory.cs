using CardsTable.Settings;
using VContainer;
using VContainer.Unity;

namespace CardsTable.CardDeck
{
    public class CardDeckFactory
    {
        private readonly IObjectResolver objectResolver;
        private readonly CardDeckSettings deckSettings;

        public CardDeckFactory(IObjectResolver objectResolver, CardDeckSettings deckSettings)
        {
            this.objectResolver = objectResolver;
            this.deckSettings = deckSettings;
        }

        public CardDeckModel Create()
        {
            var context = objectResolver.Instantiate(deckSettings.CardDeckPrefab);
            
            return context.Container.Resolve<CardDeckModel>();
        }
    }
}