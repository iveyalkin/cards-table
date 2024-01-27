using System;
using CardsTable.PlayingCard;
using UnityEngine;

namespace CardsTable.Settings
{
    [Serializable]
    public class DeckSettings
    {
        [SerializeField]
        private GameObject cardPrefab;

        [SerializeField]
        private CardData[] cards;

        public GameObject CardPrefab => cardPrefab;
        public CardData[] Cards => cards;
    }
}