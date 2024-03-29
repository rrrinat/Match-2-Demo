﻿namespace Match2.Common.StateMachine
{
    public abstract class StateMachine : IStateMachine
    {
        public IState CurrentState { get; private set; }

        protected virtual void Initialize(IState state)
        {
            CurrentState = state;
            state.Enter();
        }

        public void Update()
        {
            CurrentState.Update();
        }

        public virtual void Initialize()
        {
        }

        protected void SetState(IState state)
        {
            CurrentState.Exit();
            CurrentState = state;
            CurrentState.Enter();
        }
    }
}