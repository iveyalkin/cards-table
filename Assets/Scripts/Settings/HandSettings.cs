using System;
using CardsTable.Player;
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

        [SerializeField]
        private PlayerContext playerPrefab;

        public PlayerContext PlayerPrefab => playerPrefab;
        public int StartCardsCount => startCardsCount;
        public int MaxCardsCount => maxCardsCount;
    }
}