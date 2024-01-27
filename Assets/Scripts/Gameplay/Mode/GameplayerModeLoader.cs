using System;
using System.Threading.Tasks;
using CardsTable.Player.DI;
using CardsTable.UserState;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace CardsTable.Gameplay.Mode
{
    public class GameplayModeLoader
    {
        private const string TableSceneName = "Table";

        private readonly GameplayController gameplayController;
        private readonly UserStateRepository userStateRepository;
        private readonly PlayerFactory playerFactory;

        public event Action OnGameplayModeUnloaded = delegate { };

        public GameplayModeLoader(GameplayController gameplayController, PlayerFactory playerFactory, UserStateRepository userStateRepository)
        {
            this.gameplayController = gameplayController;
            this.playerFactory = playerFactory;
            this.userStateRepository = userStateRepository;
        }

        public async UniTask LoadGameplayMode(GameplayMode gameMode)
        {
            switch (gameMode)
            {
                case GameplayMode.PvP:
                    await LoadPvPMode();
                    break;
                case GameplayMode.BJ:
                    await LoadBJMode();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(gameMode), gameMode, null);
            }

            var userState = userStateRepository.GetState();
            gameplayController.AddPlayer(playerFactory.Create(userState));

            gameplayController.StartGame(gameMode);
        }

        private async Task LoadBJMode()
        {
            await SceneManager.LoadSceneAsync(TableSceneName, LoadSceneMode.Additive).ToUniTask();
        }

        private async Task LoadPvPMode()
        {
            await SceneManager.LoadSceneAsync(TableSceneName, LoadSceneMode.Additive).ToUniTask();

            var botState = new UserStateData {
                nickname = "Bot",
                totalScore = 0
            };

            gameplayController.AddPlayer(playerFactory.Create(botState));
        }

        public async UniTask RestartGameplayMode()
        {
            await SceneManager.UnloadSceneAsync(TableSceneName).ToUniTask();
            await SceneManager.LoadSceneAsync(TableSceneName, LoadSceneMode.Additive).ToUniTask();
        }

        public async UniTask UnloadGameplayMode()
        {
            await SceneManager.UnloadSceneAsync(TableSceneName).ToUniTask();

            OnGameplayModeUnloaded();
        }
    }
}