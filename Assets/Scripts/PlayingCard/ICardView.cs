using System;
using UnityEngine;

namespace CardsTable.PlayingCard
{
    public interface ICardView
    {
        public event Action OnDragStart;
        public event Action OnDragStop;
        public event Action OnDragUpdate;

        void FlipCard(bool shouldFaceUp);
        void Show(CardData state);
        void SetPosition(Vector2 position);
    }
}