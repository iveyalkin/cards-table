using System;
using CardsTable.CardDeck.DI;
using CardsTable.PlayingCard;
using CardsTable.PlayingCard.DI;
using UnityEngine;

namespace CardsTable.Settings
{
    [Serializable]
    public class CardDeckSettings
    {
        [SerializeField]
        private CardContext cardPrefab;

        [SerializeField]
        private CardDeckContext cardDeckPrefab;

        [SerializeField]
        private CardData[] cards;

        public CardContext CardPrefab => cardPrefab;
        public CardDeckContext CardDeckPrefab => cardDeckPrefab;
        public CardData[] Cards => cards;
    }
}