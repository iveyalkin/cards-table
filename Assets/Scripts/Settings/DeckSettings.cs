using System;
using UnityEngine;

namespace CardsTable.Settings
{
    [Serializable]
    public class DeckSettings
    {
        [SerializeField]
        private int cardsCount;

        public int CardsCount => cardsCount;
    }
}