using System;
using VContainer.Unity;

namespace CardsTable.UI.MainMenu
{
    public class MainMenuController : IInitializable, IDisposable
    {
        private readonly MainMenuView view;

        public MainMenuController(MainMenuView view)
        {
            this.view = view;
        }

        void IInitializable.Initialize()
        {
            view.OnChooseGameModeButtonClicked += OnChooseGameModeButtonClicked;
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