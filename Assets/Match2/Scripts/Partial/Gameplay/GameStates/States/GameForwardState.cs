using Match2.Common.UI.Windows;
using Match2.Partial.Loading;
using Match2.Partial.UI.Windows;
using UnityEngine;

namespace Match2.Partial.Gameplay.GameStates.States
{
    public class GameForwardState : GameState
    {
        private SceneLoader sceneLoader;
        private WindowPresenter windowPresenter;

        public GameForwardState(GameStateMachine gameStateMachine, SceneLoader sceneLoader,
            WindowPresenter windowPresenter) : base(gameStateMachine)
        {
            this.sceneLoader = sceneLoader;
            this.windowPresenter = windowPresenter;
        }

        public override async void Enter()
        {
            await windowPresenter.ShowAsync<MainMenuWindow>();
        }

        public override void Update()
        {
        }

        public override void Exit()
        {

        }
    }
}