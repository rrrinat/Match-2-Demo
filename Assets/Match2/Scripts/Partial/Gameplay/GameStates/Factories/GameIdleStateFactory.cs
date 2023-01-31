using Match2.Partial.Gameplay.GameStates.States;
using Match2.Partial.Loading;

namespace Match2.Partial.Gameplay.GameStates.Factories
{
    public class GameIdleStateFactory
    {
        private SceneLoader sceneLoader;
        
        public GameIdleStateFactory(SceneLoader sceneLoader)
        {
            this.sceneLoader = sceneLoader;
        }
        
        public GameIdleState Create(GameStateMachine gameStateMachine) => new GameIdleState(gameStateMachine, sceneLoader);
    }
}