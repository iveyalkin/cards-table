using System.Collections.Generic;
using CardsTable.PlayingCard;
using CardsTable.Settings;

namespace CardsTable
{
    public class Deck
    {
        private readonly Shuffler shuffler;
        private readonly DeckSettings deckSettings;
        private readonly List<CardModel> cards;

        public Deck(Shuffler shuffler, DeckSettings deckSettings, List<CardModel> cards)
        {
            this.shuffler = shuffler;
            this.deckSettings = deckSettings;
            this.cards = cards;
        }

        public void Shuffle()
        {
            shuffler.Shuffle(cards);
        }

        public CardModel DrawCard()
        {
            return null;
        }
    }
}
