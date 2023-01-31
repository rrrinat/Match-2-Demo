using Match2.Partial.Gameplay.GameStates.States;
using Match2.Partial.Loading;

namespace Match2.Partial.Gameplay.GameStates.Factories
{
    public class GameLevelClearStateFactory
    {
        private SceneLoader sceneLoader;
        private LevelLoader levelLoader;
        
        public GameLevelClearStateFactory(SceneLoader sceneLoader, LevelLoader levelLoader)
        {
            this.sceneLoader = sceneLoader;
            this.levelLoader = levelLoader;
        }
        
        public GameLevelClearState Create(GameStateMachine gameStateMachine) =>
            new GameLevelClearState(gameStateMachine, sceneLoader, levelLoader);
    }
}