using System.Collections.Generic;
using CardsTable.PlayingCard;
using UnityEngine;

namespace CardsTable.CardDeck
{
    public class Shuffler
    {
        public void Shuffle(List<CardData> cards)
        {
            for (var i = 1; i < cards.Count; i++)
            {
                var randomIndex = Random.Range(0, i);
                Swap(cards, i, randomIndex);
            }
        }

        private void Swap(List<CardData> cards, int i, int j)
        {
            var temp = cards[i];
            cards[i] = cards[j];
            cards[j] = temp;
        }
    }
}
