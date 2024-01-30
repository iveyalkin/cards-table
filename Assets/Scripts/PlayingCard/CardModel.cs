using System;

namespace CardsTable.PlayingCard
{
    public class CardModel
    {
        public CardData Data { get; set; }

        public event Action<CardModel> OnCardClicked = delegate { };
        public event Action<CardModel> OnCardDropped = delegate { };

        public void PickCard()
        {
            OnCardClicked(this);
        }

        public void PlaceCard()
        {
            OnCardDropped(this);
        }
    }
}