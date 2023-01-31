using Match2.Common.UI.Windows;
using Match2.Partial.Gameplay.Factories;
using Match2.Partial.Gameplay.GameStates.States;
using Match2.Partial.Loading;
using VContainer;

namespace Match2.Partial.Gameplay.GameStates.Factories
{
    public class GameLevelSpawnStateFactory
    {
        private SceneLoader sceneLoader;
        private IObjectResolver container;
        private WindowPresenter windowPresenter;

        public GameLevelSpawnStateFactory(SceneLoader sceneLoader, IObjectResolver container,
            WindowPresenter windowPresenter)
        {
            this.sceneLoader = sceneLoader;
            this.container = container;
            this.windowPresenter = windowPresenter;
        }

        public GameLevelSpawnState Create(GameStateMachine gameStateMachine) =>
            new GameLevelSpawnState(gameStateMachine, sceneLoader, container, windowPresenter);
    }
}