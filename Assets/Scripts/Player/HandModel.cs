using System.Collections.Generic;
using CardsTable.PlayingCard;
using CardsTable.Settings;

namespace CardsTable.Player
{
    public class HandModel
    {
        private readonly HandSettings handSettings;
        private readonly List<CardModel> cards = new ();

        public bool HasStartCardsCount=> handSettings.StartCardsCount == cards.Count;

        public HandModel(HandSettings handSettings)
        {
            this.handSettings = handSettings;
        }

        public void AddCard(CardModel card)
        {
            cards.Add(card);
        }

        public void RemoveCard(CardModel card)
        {
            cards.Remove(card);
        }
    }
}
