using System;
using CardsTable.Gameplay.Mode;
using CardsTable.PlayerState;
using VContainer.Unity;

namespace CardsTable.UI.MainMenu
{
    public class MainMenuController : IInitializable, IDisposable
    {
        private readonly MainMenuView view;
        private readonly PlayerStateRepository playerStateRepository;
        private readonly GameplayModeLoader gameplayModeLoader;

        public MainMenuController(MainMenuView view, PlayerStateRepository playerStateRepository,
            GameplayModeLoader gameplayModeLoader)
        {
            this.view = view;
            this.playerStateRepository = playerStateRepository;
            this.gameplayModeLoader = gameplayModeLoader;
        }

        void IInitializable.Initialize()
        {
            view.OnChooseGameModeButtonClicked += OnChooseGameModeButtonClicked;

            view.Show(playerStateRepository.GetPlayerState());

            gameplayModeLoader.OnGameplayModeUnloaded += OnGameplayModeUnloaded;
        }

        private void OnGameplayModeUnloaded()
        {
            view.Show(playerStateRepository.GetPlayerState());
        }

        void IDisposable.Dispose()
        {
            view.OnChooseGameModeButtonClicked -= OnChooseGameModeButtonClicked;
            
            gameplayModeLoader.OnGameplayModeUnloaded -= OnGameplayModeUnloaded;
        }

        private void OnChooseGameModeButtonClicked()
        {
            gameplayModeLoader.LoadGameplayMode(GameplayMode.PvP);
            view.Hide();
        }
    }
}