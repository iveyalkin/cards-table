using System;
using UnityEngine.UIElements;
using VContainer.Unity;

namespace CardsTable.UI.TableUI
{
    public class TableUIView : IInitializable
    {
        private readonly UIDocument document;

        private Button openPauseMenuButton;
        private Button restartButton;
        private Button resumeButton;
        private Button quitButton;
        private VisualElement pauseMenu;

        public event Action OnOpenPauseMenu
        {
            add => openPauseMenuButton.clicked += value;
            remove => openPauseMenuButton.clicked -= value;
        }

        public event Action OnClosePauseMenu
        {
            add => resumeButton.clicked += value;
            remove => resumeButton.clicked -= value;
        }

        public event Action OnQuitTable
        {
            add => quitButton.clicked += value;
            remove => quitButton.clicked -= value;
        }

        public event Action OnRestartTable
        {
            add => restartButton.clicked += value;
            remove => restartButton.clicked -= value;
        }

        public TableUIView(UIDocument document)
        {
            this.document = document;
        }

        void IInitializable.Initialize()
        {
            openPauseMenuButton = document.rootVisualElement.Q<Button>("open-pause-menu");
            pauseMenu = document.rootVisualElement.Q<VisualElement>("pause-menu");

            restartButton = pauseMenu.Q<Button>("restart-table");
            resumeButton = pauseMenu.Q<Button>("resume-table");
            quitButton = pauseMenu.Q<Button>("quit-table");
        }

        public void OpenPauseMenu()
        {
            pauseMenu.style.display = DisplayStyle.Flex;
        }

        public void ClosePauseMenu()
        {
            pauseMenu.style.display = DisplayStyle.None;
        }
    }
}