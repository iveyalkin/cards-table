using System;
using CardsTable.Player;
using CardsTable.UserState;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;

namespace CardsTable.Gameplay.Mode
{
    public class GameplayModeLoader
    {
        private const string TableSceneName = "Table";

        private readonly UserStateRepository userStateRepository;
        private readonly PlayerFactory playerFactory;

        public event Action OnGameplayModeUnloaded = delegate { };

        public GameplayModeLoader(PlayerFactory playerFactory, UserStateRepository userStateRepository)
        {
            this.playerFactory = playerFactory;
            this.userStateRepository = userStateRepository;
        }

        public async UniTask LoadGameplayMode(GameplayMode gameMode)
        {
            var playersCollection = new PlayersCollection();
            var userState = userStateRepository.GetState();
            playersCollection.Add(playerFactory.Create(userState));

            switch (gameMode)
            {
                case GameplayMode.PvP:
                    LoadBots(playersCollection);
                    break;
                case GameplayMode.BJ:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(gameMode), gameMode, null);
            }

            using (LifetimeScope.Enqueue(builder =>
            {
                builder.RegisterInstance(gameMode);
                builder.RegisterInstance(playersCollection);
            }))
            {
                await SceneManager.LoadSceneAsync(TableSceneName, LoadSceneMode.Additive).ToUniTask();
            }
        }

        private void LoadBots(PlayersCollection playersCollection)
        {
            var botState = new UserStateData
            {
                playerState = new PlayerState
                {
                    gameId = "Bot",
                    score = 0
                }
            };

            playersCollection.Add(playerFactory.Create(botState));
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