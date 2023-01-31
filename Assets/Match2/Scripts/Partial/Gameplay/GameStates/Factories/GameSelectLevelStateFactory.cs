using Match2.Common.UI.Windows;
using Match2.Partial.Gameplay.GameStates.States;
using Match2.Partial.Loading;
using Match2.Partial.Messages;
using MessagePipe;

namespace Match2.Partial.Gameplay.GameStates.Factories
{
    public class GameSelectLevelStateFactory
    {
        private SceneLoader sceneLoader;
        private LevelLoader levelLoader;
        private WindowPresenter windowPresenter;
        private ISubscriber<SelectLevelFrameMessage> subscriber;

        public GameSelectLevelStateFactory(SceneLoader sceneLoader, LevelLoader levelLoader,
            WindowPresenter windowPresenter, ISubscriber<SelectLevelFrameMessage> subscriber)
        {
            this.sceneLoader = sceneLoader;
            this.levelLoader = levelLoader;
            this.windowPresenter = windowPresenter;
            this.subscriber = subscriber;
        }

        public GameSelectLevelState Create(GameStateMachine gameStateMachine) =>
            new GameSelectLevelState(gameStateMachine, sceneLoader, levelLoader, windowPresenter, subscriber);
    }
}