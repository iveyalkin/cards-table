using System;
using UnityEngine;

namespace CardsTable.Settings
{
    [Serializable]
    public class HandSettings
    {
        [SerializeField]
        private int startCardsCount;

        [SerializeField]
        private int maxCardsCount;

        public int StartCardsCount => startCardsCount;
        public int MaxCardsCount => maxCardsCount;
    }
}