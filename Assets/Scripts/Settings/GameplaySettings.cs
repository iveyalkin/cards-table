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
        private DeckSettings deckSettings;

        [SerializeField]
        private HandSettings handSettings;

        public SessionSettings SessionSettings => sessionSettings;
        public DeckSettings DeckSettings => deckSettings;
        public HandSettings HandSettings => handSettings;
    }
}