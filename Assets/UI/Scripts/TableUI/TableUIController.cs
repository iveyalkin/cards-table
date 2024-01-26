using System;
using CardsTable.Gameplay.Mode;
using VContainer.Unity;

namespace CardsTable.UI.TableUI
{
    public class TableUIController : IInitializable, IDisposable
    {
        private readonly TableUIView view;
        private readonly GameplayModeLoader gameplayModeLoader;

        public TableUIController(TableUIView view, GameplayModeLoader gameplayModeLoader)
        {
            this.view = view;
            this.gameplayModeLoader = gameplayModeLoader;
        }

        void IInitializable.Initialize()
        {
            view.OnOpenPauseMenu += OpenPauseMenu;
            view.OnClosePauseMenu += ClosePauseMenu;
            view.OnRestartTable += RestartTable;
            view.OnQuitTable += QuitTable;
        }

        void IDisposable.Dispose()
        {
            view.OnOpenPauseMenu -= OpenPauseMenu;
            view.OnClosePauseMenu -= ClosePauseMenu;
            view.OnRestartTable -= RestartTable;
            view.OnQuitTable -= QuitTable;
        }

        private void OpenPauseMenu()
        {
            view.OpenPauseMenu();
        }

        private void ClosePauseMenu()
        {
           view.ClosePauseMenu();
        }

        private void RestartTable()
        {
            gameplayModeLoader.RestartGameplayMode();
        }

        private void QuitTable()
        {
           gameplayModeLoader.UnloadGameplayMode();
        }
    }
}
