using Match2.Partial.Loading;
using UnityEngine;

namespace Match2.Partial.Gameplay.GameStates.States
{
    public class GameLevelClearState : GameState
    {
        private SceneLoader sceneLoader;
        private LevelLoader levelLoader;

        public GameLevelClearState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LevelLoader levelLoader)
            : base(gameStateMachine)
        {
            this.sceneLoader = sceneLoader;
            this.levelLoader = levelLoader;
        }

        public override void Enter()
        {
            Debug.Log($"GameLevelClearState Enter");
            levelLoader.Unload();
        }

        public override void Update()
        {
        }

        public override void Exit()
        {
        }
    }
}