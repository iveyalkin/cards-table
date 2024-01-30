using System.Collections.Generic;
using CardsTable.PlayingCard;
using CardsTable.Settings;
using UnityEngine.Pool;

namespace CardsTable.CardDeck
{
    public class CardDeckModel
    {
        private readonly Shuffler shuffler;
        private readonly CardDeckSettings deckSettings;

        private Queue<CardData> cards;

        public IEnumerable<CardData> Cards => cards;

        public CardDeckModel(Shuffler shuffler, CardDeckSettings deckSettings)
        {
            this.shuffler = shuffler;
            this.deckSettings = deckSettings;
            this.cards = new Queue<CardData>(deckSettings.Cards);
        }

        public CardData DrawCard()
        {
            return cards.Dequeue();
        }

        public void Shuffle()
        {
            var tmpDeck = ListPool<CardData>.Get();
            tmpDeck.AddRange(cards);
            shuffler.Shuffle(tmpDeck);
            cards = new Queue<CardData>(tmpDeck);
            ListPool<CardData>.Release(tmpDeck);
        }
    }
}