using System;
using System.Collections.Generic;
using CardsTable.CardDeck;
using CardsTable.Player;
using CardsTable.PlayingCard;
using CardsTable.Settings;

namespace CardsTable.Table
{
    public class TableModel
    {
        private readonly TableSettings tableSettings;
        private readonly PlayersCollection players;

        private readonly List<CardModel> tableCards = new();

        public TableModel(TableSettings tableSettings, PlayersCollection players)
        {
            this.tableSettings = tableSettings;
            this.players = players;
        }

        public event Action<CardModel> OnNewCard = delegate { };

        public void AddCard(CardModel cardModel)
        {
            OnNewCard(cardModel);
        }
    }
}