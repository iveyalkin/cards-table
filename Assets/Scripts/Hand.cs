using System.Collections;
using System.Collections.Generic;
using CardsTable.Settings;
using UnityEngine;

namespace CardsTable
{
    public class Hand
    {
        private readonly HandSettings handSettings;
        private readonly List<Card> cards = new ();

        public bool HasStartCardsCount=> handSettings.StartCardsCount == cards.Count;

        public void AddCard(Card card)
        {
            cards.Add(card);
        }

        public void RemoveCard(Card card)
        {
            cards.Remove(card);
        }
    }
}
