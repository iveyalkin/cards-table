using System;

namespace CardsTable.PlayingCard
{
    public class CardModel
    {
        public CardData Data { get; }

        public event Action<CardModel> OnCardClicked = delegate { };
        public event Action<CardModel> OnCardDragged = delegate { };
        public event Action<CardModel> OnCardDropped = delegate { };

        public CardModel(CardData data)
        {
            Data = data;
        }
    }
}