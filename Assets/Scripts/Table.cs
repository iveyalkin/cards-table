using System.Collections.Generic;
using CardsTable.CardDeck;
using CardsTable.Player;
using CardsTable.PlayingCard;
using CardsTable.Settings;

namespace CardsTable
{
    public class Table
    {
        private readonly TableSettings tableSettings;
        private readonly PlayersCollection players;
        private readonly CardDeckModel cardDeck;

        private readonly List<CardModel> tableCards = new();

        public Table(TableSettings tableSettings, PlayersCollection players, CardDeckModel cardDeck)
        {
            this.tableSettings = tableSettings;
            this.players = players;
            this.cardDeck = cardDeck;
        }

        public class Factory
        {
            public Table Create(TableSettings settings, PlayersCollection players, CardDeckModel cardDeck)
            {
                return new Table(settings, players, cardDeck);
            }
        }
    }
}
