using System.Collections.Generic;
using CardsTable.PlayingCard;
using CardsTable.PlayingCard.DI;
using CardsTable.Settings;
using VContainer;

namespace CardsTable
{
    public class DeckFactory
    {
        private readonly IObjectResolver objectResolver;
        private readonly DeckSettings deckSettings;
        private readonly CardFactory cardFactory;

        public DeckFactory(IObjectResolver objectResolver, DeckSettings deckSettings, CardFactory cardFactory)
        {
            this.objectResolver = objectResolver;
            this.deckSettings = deckSettings;
            this.cardFactory = cardFactory;
        }

        public Deck Create()
        {
            var cardsCount = deckSettings.Cards.Length;
            var cards = new List<CardModel>(cardsCount);

            for (var i = 0; i < cards.Count; i++)
            {
                var card = cardFactory.Create(deckSettings.Cards[i]);
                cards.Add(card);
            }

            return new Deck(objectResolver.Resolve<Shuffler>(), deckSettings, cards);
        }
    }
}