using System;
using UnityEngine;

namespace CardsTable.PlayingCard
{
    public class CardModel
    {
        public CardData Data { get; set; }

        public Vector2 Position { get; private set; }
        public bool IsFaceUp { get; private set; }

        public event Action<CardModel> OnCardClicked = delegate { };
        public event Action<CardModel> OnCardDropped = delegate { };
        public event Action<bool> OnCardFlipped = delegate { };
        public event Action<Vector2> OnPositionUpdated = delegate { };

        public CardModel(CardData data)
        {
            Data = data;
        }

        public void PickCard()
        {
            OnCardClicked(this);
        }

        public void PlaceCard()
        {
            OnCardDropped(this);
        }

        public void AlignWith(Vector2 origin)
        {
            Position = origin;
            OnPositionUpdated(Position);
        }

        public void SetFaceUp(bool shouldFaceUp)
        {
            if (IsFaceUp == shouldFaceUp)
                return;

            IsFaceUp = shouldFaceUp;

            OnCardFlipped(shouldFaceUp);
        }
    }
}