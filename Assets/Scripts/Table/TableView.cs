using System;
using System.Collections.Generic;
using CardsTable.CardDeck;
using CardsTable.Player;
using CardsTable.PlayingCard;
using CardsTable.Settings;
using UnityEngine.UIElements;
using VContainer.Unity;

namespace CardsTable.Table
{
    public class TableView : IInitializable, IDisposable
    {
        private readonly UIDocument document;

        public TableView(UIDocument document)
        {
            this.document = document;
        }

        void IInitializable.Initialize()
        {
            
        }

        void IDisposable.Dispose()
        {

        }
    }
}
