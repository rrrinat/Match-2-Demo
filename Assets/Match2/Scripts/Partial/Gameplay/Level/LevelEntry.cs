using System;
using Match2.Partial.Gameplay.Level.LevelStates;
using VContainer;
using VContainer.Unity;

namespace Match2.Partial.Gameplay.Level
{
    public class LevelEntry : IStartable, ITickable, IDisposable
    {
        [Inject] private LevelStateMachine levelStateMachine;
        
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