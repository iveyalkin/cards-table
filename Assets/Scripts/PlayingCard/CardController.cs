using System;
using UnityEngine;
using VContainer.Unity;

namespace CardsTable.PlayingCard
{
    public class CardController : IInitializable, IDisposable
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
            view.OnDragStart += OnDragStart;
            view.OnDragStop += OnDragStop;
            view.OnDragUpdate += OnDragUpdate;

            model.OnCardFlipped += view.FlipCard;
            model.OnPositionUpdated += view.SetPosition;
        }

        void IDisposable.Dispose()
        {
            view.OnDragStart -= OnDragStart;
            view.OnDragStop -= OnDragStop;
            view.OnDragUpdate -= OnDragUpdate;

            model.OnPositionUpdated -= view.SetPosition;
        }

        private void OnDragUpdate()
        {
            Debug.Log("OnDragUpdate");
        }

        private void OnDragStop()
        {
            Debug.Log("OnDragStop");

            model.PlaceCard();
        }

        private void OnDragStart()
        {
            Debug.Log("OnDragStart");

            model.PickCard();
        }
    }
}
