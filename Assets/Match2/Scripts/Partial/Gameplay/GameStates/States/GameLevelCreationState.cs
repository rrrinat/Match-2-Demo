using Match2.Common.UI.Windows;
using Match2.Partial.Loading;
using Match2.Partial.Loading.Enums;

namespace Match2.Partial.Gameplay.GameStates.States
{
    public class GameLevelCreationState : GameState
    {
        private SceneLoader sceneLoader;
        private LevelLoader levelLoader;
        private WindowPresenter windowPresenter;

        public GameLevelCreationState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LevelLoader levelLoader, WindowPresenter windowPresenter)
            : base(gameStateMachine)
        {
            this.sceneLoader = sceneLoader;
            this.levelLoader = levelLoader;
            this.windowPresenter = windowPresenter;
        }

        public override async void Enter()
        {
            // await sceneLoader.LoadSceneAsync(SceneType.Game);
            // await levelLoader.Load();
            //
            // gameStateMachine.SetState<GameLevelSpawnState>();   
        }

        public override void Update()
        {
        }

        public override void Exit()
        {
        }
    }
}