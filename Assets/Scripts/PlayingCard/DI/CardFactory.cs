using CardsTable.Settings;
using VContainer;
using VContainer.Unity;

namespace CardsTable.PlayingCard.DI
{
    public class CardFactory
    {
        private readonly IObjectResolver objectResolver;
        private readonly DeckSettings deckSettings;

        public CardFactory(IObjectResolver objectResolver, DeckSettings deckSettings)
        {
            this.objectResolver = objectResolver;
            this.deckSettings = deckSettings;
        }

        public CardModel Create(CardData data)
        {   
            var card = objectResolver.Instantiate(deckSettings.CardPrefab);

            throw new System.NotImplementedException();
        }
    }
}