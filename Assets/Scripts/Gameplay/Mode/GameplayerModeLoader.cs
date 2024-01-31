using System;
using CardsTable.CardDeck;
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
        private readonly CardDeckFactory cardDeckFactory;

        public event Action OnGameplayModeUnloaded = delegate { };

        public GameplayModeLoader(PlayerFactory playerFactory, CardDeckFactory cardDeckFactory,
            UserStateRepository userStateRepository)
        {
            this.playerFactory = playerFactory;
            this.cardDeckFactory = cardDeckFactory;
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

            var cardDeck = cardDeckFactory.Create();

            using (LifetimeScope.Enqueue(builder =>
            {
                builder.RegisterInstance(gameMode);
                builder.RegisterInstance(playersCollection);
                builder.RegisterInstance(cardDeck);
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