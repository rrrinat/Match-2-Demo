using Match2.Common.UI.Windows;
using Match2.Partial.Gameplay.GameStates;
using VContainer;
using VContainer.Unity;

namespace Match2.Partial.Gameplay
{
    public class MainMenuEntryPoint : IStartable, ITickable
    {
        [Inject] private GameStateMachine gameStateMachine;
        //[Inject] private WindowPresenter windowPresenter;
        
        public void Start()
        {
            //windowPresenter.ShowAsync<MyFirstWindow>().Forget();
            
            gameStateMachine.Initialize();
        }

        public void Tick()
        {
            gameStateMachine.Update();
        }
    }
}