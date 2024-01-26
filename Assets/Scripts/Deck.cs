using System.Collections;
using System.Collections.Generic;
using CardsTable.Settings;
using UnityEngine;

namespace CardsTable
{
    public class Deck
    {
        private readonly Shuffler shuffler;
        private readonly DeckSettings deckSettings;
        private readonly List<Card> cards = new();

        public void Shuffle()
        {
            shuffler.Shuffle(cards);
        }

        public Card DrawCard()
        {
            return null;
        }
    }
}
