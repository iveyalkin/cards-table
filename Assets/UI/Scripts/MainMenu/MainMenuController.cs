using System;
using CardsTable.PlayerState;
using VContainer.Unity;

namespace CardsTable.UI.MainMenu
{
    public class MainMenuController : IInitializable, IDisposable
    {
        private readonly MainMenuView view;
        private readonly PlayerStateData playerStateData;

        public MainMenuController(MainMenuView view, PlayerStateData playerStateData)
        {
            this.view = view;
            this.playerStateData = playerStateData;
        }

        void IInitializable.Initialize()
        {
            view.OnChooseGameModeButtonClicked += OnChooseGameModeButtonClicked;

            view.Show(playerStateData);
        }

        void IDisposable.Dispose()
        {
            view.OnChooseGameModeButtonClicked -= OnChooseGameModeButtonClicked;
        }

        private void OnChooseGameModeButtonClicked()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Table", UnityEngine.SceneManagement.LoadSceneMode.Additive);
            view.Hide();
        }
    }
}