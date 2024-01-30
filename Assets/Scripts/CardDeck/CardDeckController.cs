using System;
using CardsTable.PlayingCard;
using VContainer.Unity;

namespace CardsTable.CardDeck
{
    public class CardDeckController : IInitializable, IDisposable
    {
        private readonly CardDeckView view;
        private readonly CardDeckModel model;
        private readonly CardViewFactory cardFactory;

        public CardDeckController(CardDeckView view, CardDeckModel model, CardViewFactory cardFactory)
        {
            this.view = view;
            this.model = model;
            this.cardFactory = cardFactory;
        }

        void IInitializable.Initialize()
        {
            view.OnDrawClick += OnDrawCard;
        }

        void IDisposable.Dispose()
        {
            view.OnDrawClick -= OnDrawCard;
        }

        private void OnDrawCard()
        {
            var data = model.DrawCard();
            var cardModel = cardFactory.Create(data);
        }
    }
}
