using Match2.Common.UI.Windows;
using Match2.Partial.Loading;
using UnityEngine;
using VContainer;

namespace Match2.Partial.Gameplay.GameStates.States
{
    public class GameLevelSpawnState : GameState
    {
        private SceneLoader sceneLoader;
        private IObjectResolver container;
        private WindowPresenter windowPresenter;

        public GameLevelSpawnState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, IObjectResolver container, WindowPresenter windowPresenter)
            : base(gameStateMachine)
        {
            this.sceneLoader = sceneLoader;
            this.container = container;
            this.windowPresenter = windowPresenter;
            
        }

        public override async void Enter()
        {

        }

        public override void Update()
        {
        }

        public override void Exit()
        {
        }
    }
}