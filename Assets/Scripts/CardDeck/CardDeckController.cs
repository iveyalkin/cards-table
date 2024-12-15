using System;
using VContainer.Unity;

namespace CardsTable.CardDeck
{
    public class CardDeckController : IPostInitializable, IDisposable
    {
        private readonly CardDeckView view;
        private readonly CardDeckModel model;

        public CardDeckController(CardDeckView view, CardDeckModel model)
        {
            this.view = view;
            this.model = model;;
        }

        void IPostInitializable.PostInitialize()
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
