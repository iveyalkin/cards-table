using System;
using CardsTable.PlayingCard;
using VContainer.Unity;

namespace CardsTable.Player.Hand
{
    public class HandController : IInitializable, IDisposable
    {
        private readonly HandView view;
        private readonly HandModel model;
        private readonly CardViewFactory cardFactory;

        public HandController(HandView view, HandModel model, CardViewFactory cardFactory)
        {
            this.view = view;
            this.model = model;
            this.cardFactory = cardFactory;
        }

        void IInitializable.Initialize()
        {
            model.OnCardAdded += OnCardAdded;
            model.OnCardRemoved += OnCardRemoved;
        }

        void IDisposable.Dispose()
        {
            model.OnCardAdded -= OnCardAdded;
            model.OnCardRemoved -= OnCardRemoved;
        }

        private void OnCardAdded(CardData card)
        {
            var cardModel = cardFactory.Create(card);
            var vacantSlot = view.OccupySlot(card);
            cardModel.AlignWith(vacantSlot);
            cardModel.SetFaceUp(true);
        }

        private void OnCardRemoved(CardData card)
        {
            view.ReleaseSlot(card);
        }
    }
}