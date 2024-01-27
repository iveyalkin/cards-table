using System.Collections.Generic;
using CardsTable.Player;
using CardsTable.PlayingCard;
using CardsTable.Settings;

namespace CardsTable
{
    public class Table
    {
        private readonly TableSettings tableSettings;
        private readonly PlayersCollection players;
        private readonly Deck deck;

        private readonly List<CardModel> tableCards = new();

        public Table(TableSettings tableSettings, PlayersCollection players, Deck deck)
        {
            this.tableSettings = tableSettings;
            this.players = players;
            this.deck = deck;
        }

        public class Factory
        {
            public Table Create(TableSettings settings, PlayersCollection players, Deck deck)
            {
                return new Table(settings, players, deck);
            }
        }
    }
}
