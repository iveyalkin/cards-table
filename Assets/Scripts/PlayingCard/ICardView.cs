using System;

namespace CardsTable.PlayingCard
{
    public interface ICardView
    {
        public event Action OnDragStart;
        public event Action OnDragStop;
        public event Action OnDragUpdate;
        
        void Show(CardData state);
    }
}