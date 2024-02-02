using System;
using UnityEngine.UIElements;
using VContainer.Unity;
using CardsTable.UserState;

namespace CardsTable.UI.MainMenu
{
    public class MainMenuView: IStartable
    {
        private readonly UIDocument document;

        private TextField nicknameTextField;
        private Label totalScoreLabel;
        private Toggle muteSfxToggle;
        private Toggle muteAmbientToggle;
        private Button chooseGameModeButton;

        public event Action OnChooseGameModeButtonClicked
        {
            add => chooseGameModeButton.clicked += value;
            remove => chooseGameModeButton.clicked -= value;
        }

        public MainMenuView(UIDocument document)
        {
            this.document = document;
        }

        void IStartable.Start()
        {
            nicknameTextField = document.rootVisualElement.Q<TextField>("nickname");
            totalScoreLabel = document.rootVisualElement.Q<Label>("total-score");
            muteSfxToggle = document.rootVisualElement.Q<Toggle>("mute-sfx");
            muteAmbientToggle = document.rootVisualElement.Q<Toggle>("mute-ambient");
            chooseGameModeButton = document.rootVisualElement.Q<Button>("choose-game-mode");
        }

        public void Show(UserStateData playerStateData)
        {
            document.rootVisualElement.style.display = DisplayStyle.Flex;

            nicknameTextField.value = playerStateData.playerState.gameId;
            totalScoreLabel.text = $"{playerStateData.playerState.score}"; // todo: use formatter to represent it like 2kk
            muteSfxToggle.value = playerStateData.isSfxMuted;
            muteAmbientToggle.value = playerStateData.isAmbientMuted;
        }

        public void Hide()
        {
            document.rootVisualElement.style.display = DisplayStyle.None;
        }
    }
}