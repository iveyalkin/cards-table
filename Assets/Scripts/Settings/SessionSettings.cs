using System;
using UnityEngine;

namespace CardsTable.Settings
{
    [Serializable]
    public class SessionSettings
    {
        [SerializeField]
        [Tooltip("Table settings for each players count, index [0] - default settings")]
        private TableSettings[] tables = { new TableSettings() };

        public TableSettings[] Tables => tables;

        public int MaxPlayersCount => Mathf.Max(0, tables.Length - 1);

        public TableSettings[] TableSettings => tables;
    }
}