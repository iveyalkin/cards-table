using System;
using CardsTable.Gameplay.Mode;
using CardsTable.UserState;
using Cysharp.Threading.Tasks;
using VContainer.Unity;

namespace CardsTable.UI.MainMenu
{
    public class MainMenuController : IInitializable, IStartable, IDisposable
    {
        private readonly MainMenuView view;
        private readonly UserStateRepository playerStateRepository;
        private readonly GameplayModeLoader gameplayModeLoader;

        public MainMenuController(MainMenuView view, UserStateRepository playerStateRepository,
            GameplayModeLoader gameplayModeLoader)
        {
            this.view = view;
            this.playerStateRepository = playerStateRepository;
            this.gameplayModeLoader = gameplayModeLoader;
        }

        void IInitializable.Initialize()
        {
            view.OnChooseGameModeButtonClicked += OnChooseGameModeButtonClicked;
            gameplayModeLoader.OnGameplayModeUnloaded += OnGameplayModeUnloaded;
        }

        void IStartable.Start()
        {
            view.Show(playerStateRepository.GetState());
        }

        private void OnGameplayModeUnloaded()
        {
            view.Show(playerStateRepository.GetState());
        }

        void IDisposable.Dispose()
        {
            view.OnChooseGameModeButtonClicked -= OnChooseGameModeButtonClicked;
            
            gameplayModeLoader.OnGameplayModeUnloaded -= OnGameplayModeUnloaded;
        }

        private void OnChooseGameModeButtonClicked()
        {
            gameplayModeLoader.LoadGameplayMode(GameplayMode.PvP)
                .ContinueWith(OnGameModeLoaded)
                .Forget();
        }

        private void OnGameModeLoaded()
        {
            view.Hide();
        }
    }
}