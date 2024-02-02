using System;
using UnityEngine;

namespace CardsTable.PlayingCard
{
    public class CardModel
    {
        private CardData data;
        private bool isInteractable;

        public CardData Data => data;

        public Vector2 Position { get; private set; }
        public bool IsInteractable
        {
            get => isInteractable;
            set
            {
                if (isInteractable == value)
                    return;

                isInteractable = value;
                OnInteractableChanged(value);
            }
        }

        public event Action<CardModel> OnCardClicked = delegate { };
        public event Action<CardModel> OnCardDropped = delegate { };
        public event Action<bool> OnCardFlipped = delegate { };
        public event Action<Vector2> OnPositionUpdated = delegate { };
        public event Action<bool> OnInteractableChanged = delegate { };

        public CardModel(CardData data)
        {
            this.data = data;
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
            if (data.isFaceUp == shouldFaceUp)
                return;

            data.isFaceUp = shouldFaceUp;

            OnCardFlipped(shouldFaceUp);
        }
    }
}