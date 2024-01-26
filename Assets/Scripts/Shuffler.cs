using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardsTable
{
    public class Shuffler
    {
        public void Shuffle(List<Card> cards)
        {
            Swap(cards, 0, 1);

            for (var i = 2; i < cards.Count; i++)
            {
                var randomIndex = Random.Range(0, i + 1);
                Swap(cards, i, randomIndex);
            }
        }

        private void Swap(List<Card> cards, int i, int j)
        {
            var temp = cards[i];
            cards[i] = cards[j];
            cards[j] = temp;
        }
    }
}
