using Match2.Partial.Loading;
using UnityEngine;

namespace Match2.Partial.Gameplay.GameStates.States
{
    public class GameIdleState : GameState
    {
        private SceneLoader sceneLoader;
        
        public GameIdleState(GameStateMachine gameStateMachine, SceneLoader sceneLoader) : base(gameStateMachine)
        {
            this.sceneLoader = sceneLoader;
        }

        public override async void Enter()
        {
            gameStateMachine.SetState<GameForwardState>();
        }

        public  override void Update()
        {

        }

        public override void Exit()
        {
            
        }
    }
}
