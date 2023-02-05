using Cysharp.Threading.Tasks;
using Match2.Common.UI.Windows;
using Match2.Partial.Gameplay.GameStates;
using Match2.Partial.UI.Windows;
using VContainer;
using VContainer.Unity;

namespace Match2.Partial.Gameplay
{
    public class MainMenuEntryPoint : IStartable, ITickable
    {
        [Inject] private GameStateMachine gameStateMachine;

        public void Start()
        {
            gameStateMachine.Initialize();
        }

        public void Tick()
        {
            gameStateMachine.Update();
        }
    }
}