using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace CardsTable.PlayingCard
{
    [Serializable]
    public struct CardData
    {
        public bool isFaceUp;
        public int rank;
        public VectorImage suit;
        public Color color;
    }
}