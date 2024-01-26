using System;
using UnityEngine;

namespace CardsTable.Settings
{
    [Serializable]
    public class TableSettings
    {
        [SerializeField]
        private int maxCardsCount;

        public int MaxCardsCount => maxCardsCount;
    }
}