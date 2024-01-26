using System;
using UnityEngine.UIElements;
using VContainer.Unity;

namespace CardsTable.UI.MainMenu
{
    public class MainMenuView: IInitializable
    {
         private readonly UIDocument document;

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

        void IInitializable.Initialize()
        {
            chooseGameModeButton = document.rootVisualElement.Q<Button>("choose-game-mode");
        }

        public void Show()
        {
            document.rootVisualElement.style.display = DisplayStyle.Flex;
        }

        public void Hide()
        {
            document.rootVisualElement.style.display = DisplayStyle.None;
        }
    }
}