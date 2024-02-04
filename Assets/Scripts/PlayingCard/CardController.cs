using System;
using VContainer.Unity;

namespace CardsTable.PlayingCard
{
    public class CardController : IInitializable, IStartable, IDisposable
    {
        private readonly CardModel model;
        private readonly ICardView view;

        public CardController(CardModel model, ICardView view)
        {
            this.model = model;
            this.view = view;
        }

        void IInitializable.Initialize()
        {
            view.OnPicked += OnPicked;
            view.OnPlaced += OnPlace;

            model.OnCardFlipped += view.FlipCard;
            model.OnPositionUpdated += view.SetPosition;
        }

        void IStartable.Start()
        {
            model.OnInteractableChanged += view.SetInteractable;
            view.Show(model.Data);
        }

        void IDisposable.Dispose()
        {
            view.OnPicked -= OnPicked;
            view.OnPlaced -= OnPlace;

            model.OnInteractableChanged -= view.SetInteractable;
            model.OnPositionUpdated -= view.SetPosition;
        }

        private void OnPlace()
        {
            model.PlaceCard();
        }

        private void OnPicked()
        {
            model.PickCard();
        }
    }
}
