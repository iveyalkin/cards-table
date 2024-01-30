using System;
using UnityEngine;

namespace CardsTable.Settings
{
    [CreateAssetMenu(fileName = "GameplaySettings", menuName = "Game/Gameplay Settings")]
    public class GameplaySettings : ScriptableObject
    {
        [SerializeField]
        private SessionSettings sessionSettings;

        [SerializeField]
        private CardDeckSettings deckSettings;

        [SerializeField]
        private HandSettings handSettings;

        public SessionSettings SessionSettings => sessionSettings;
        public CardDeckSettings DeckSettings => deckSettings;
        public HandSettings HandSettings => handSettings;
    }
}