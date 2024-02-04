using System;
using UnityEngine;

namespace CardsTable.PlayingCard
{
    public interface ICardView
    {
        public event Action OnPicked;
        public event Action OnPlaced;

        void FlipCard(bool shouldFaceUp);
        void Show(CardData state);
        void SetPosition(Vector2 position);
        void SetInteractable(bool isInteractable);
    }
}