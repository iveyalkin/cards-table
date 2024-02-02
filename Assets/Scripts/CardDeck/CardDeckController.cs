using System;
using VContainer.Unity;

namespace CardsTable.CardDeck
{
    public class CardDeckController : IInitializable, IDisposable
    {
        private readonly CardDeckView view;
        private readonly CardDeckModel model;

        public CardDeckController(CardDeckView view, CardDeckModel model)
        {
            this.view = view;
            this.model = model;;
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
        }
    }
}
