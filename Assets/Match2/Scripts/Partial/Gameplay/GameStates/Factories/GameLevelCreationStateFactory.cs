using Match2.Common.UI.Windows;
using Match2.Partial.Gameplay.GameStates.States;
using Match2.Partial.Loading;

namespace Match2.Partial.Gameplay.GameStates.Factories
{
    public class GameLevelCreationStateFactory
    {
        private SceneLoader sceneLoader;
        private LevelLoader levelLoader;
        private WindowPresenter windowPresenter;
        
        public GameLevelCreationStateFactory(SceneLoader sceneLoader, LevelLoader levelLoader, WindowPresenter windowPresenter)
        {
            this.sceneLoader = sceneLoader;
            this.levelLoader = levelLoader;
            this.windowPresenter = windowPresenter;
        }

        public GameLevelCreationState Create(GameStateMachine gameStateMachine) =>
            new GameLevelCreationState(gameStateMachine, sceneLoader, levelLoader, windowPresenter);
    }
}