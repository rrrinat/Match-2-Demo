using System;
using Cysharp.Threading.Tasks;
using Match2.Common.UI.Windows;
using Match2.Partial.Gameplay.Level.LevelStates;
using Match2.Partial.UI.Windows;
using VContainer;
using VContainer.Unity;

namespace Match2.Partial.Gameplay.Level
{
    public class LevelEntry : IStartable, ITickable, IDisposable
    {
        [Inject] private LevelStateMachine levelStateMachine;

        [Inject] private GoalsAmountCounter goalsAmountCounter;
        [Inject] private PlayerMovesCounter playerMovesCounter;
        
        public void Start()
        {
            levelStateMachine.Initialize();
        }
        
        public void Tick()
        {
            levelStateMachine.Update();
        }

        public void Dispose()
        {

        }
    }
}