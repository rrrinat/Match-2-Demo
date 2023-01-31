using Match2.Common.UI.Windows;
using Match2.Partial.Gameplay.GameStates.States;
using Match2.Partial.Loading;

namespace Match2.Partial.Gameplay.GameStates.Factories
{
    public class GameForwardStateFactory
    {
        private SceneLoader sceneLoader;
        private WindowPresenter windowPresenter;
        
        public GameForwardStateFactory(SceneLoader sceneLoader, WindowPresenter windowPresenter)
        {
            this.sceneLoader = sceneLoader;
            this.windowPresenter = windowPresenter;
        }
        
        public GameForwardState Create(GameStateMachine gameStateMachine) => new GameForwardState(gameStateMachine, sceneLoader, windowPresenter);
    }
}