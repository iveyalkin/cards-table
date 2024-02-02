using System;
using System.Collections.Generic;
using CardsTable.PlayingCard;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer.Unity;

namespace CardsTable.Player.Hand
{
    public class HandView : IStartable, IDisposable
    {
        private readonly UIDocument uiDocument;

        private List<VisualElement> cardSlots;

        private readonly Dictionary<CardData, VisualElement> occupiedSlots = new();

        public IReadOnlyList<VisualElement> CardSlots => cardSlots;

        public HandView(UIDocument uiDocument)
        {
            this.uiDocument = uiDocument;
        }

        void IStartable.Start()
        {
            cardSlots = uiDocument.rootVisualElement.Query<VisualElement>(className: "card-slot")
                .ToList();
        }

        void IDisposable.Dispose()
        {
            cardSlots.Clear();
            occupiedSlots.Clear();
        }

        public Vector2 OccupySlot(CardData card)
        {
            if (cardSlots.Count == 0)
            {
                Debug.LogError("No vacant slots");
                return default;
            }

            var slot = cardSlots[^1];
            cardSlots.RemoveAt(cardSlots.Count - 1);
            occupiedSlots.Add(card, slot);

            return slot.worldBound.min + (Vector2)slot.transform.position;
        }

        public void ReleaseSlot(CardData card)
        {
            if (!occupiedSlots.TryGetValue(card, out var slot))
            {
                Debug.LogError($"Card {card} is not in hand");
                return;
            }

            occupiedSlots.Remove(card);
            cardSlots.Add(slot);
        }

        public void SetActive(bool isActiveHand)
        {
            
        }
    }
}