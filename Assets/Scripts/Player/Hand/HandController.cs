using System;
using CardsTable.PlayingCard;
using VContainer.Unity;

namespace CardsTable.Player.Hand
{
    public class HandController : IInitializable, IStartable, IDisposable
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

        void IStartable.Start()
        {
            view.SetActive(model.IsActiveHand);
            SetActiveHand(model.IsActiveHand);

            model.OnActiveHandCahnge += SetActiveHand;
        }

        void IDisposable.Dispose()
        {
            model.OnCardAdded -= OnCardAdded;
            model.OnCardRemoved -= OnCardRemoved;

            model.OnActiveHandCahnge -= SetActiveHand;
        }

        private void SetActiveHand(bool isActiveHand)
        {
            view.SetActive(isActiveHand);

            foreach (var card in model.cardModels.Values)
            {
                card.IsInteractable = isActiveHand;
            }
        }

        private void OnCardAdded(CardData card)
        {
            var cardModel = cardFactory.Create(card);
            model.cardModels.Add(card, cardModel);
            cardModel.IsInteractable = model.IsActiveHand;

            var vacantSlot = view.OccupySlot(card);
            cardModel.AlignWith(vacantSlot);
        }

        private void OnCardRemoved(CardData card)
        {
            view.ReleaseSlot(card);
            model.cardModels.Remove(card);
        }
    }
}