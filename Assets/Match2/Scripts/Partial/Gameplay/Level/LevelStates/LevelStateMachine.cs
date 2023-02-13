using System;
using System.Collections.Generic;
using Match2.Common.StateMachine;
using Match2.Partial.Gameplay.Level.LevelStates.Factories;
using Match2.Partial.Gameplay.Level.LevelStates.States;
using VContainer;

namespace Match2.Partial.Gameplay.Level.LevelStates
{
    public class LevelStateMachine : StateMachine
    {
        private readonly Dictionary<Type, LevelState> levelStates = new Dictionary<Type, LevelState>();

        [Inject] private LevelClearStateFactory levelClearStateFactory;
        [Inject] private LevelIdleStateFactory levelIdleStateFactory;
        [Inject] private LevelSpawnStateFactory levelSpawnStateFactory;
        [Inject] private LevelPlayerActionStateFactory levelPlayerActionStateFactory;
        [Inject] private LevelDestroyingMatchesStateFactory levelDestroyingMatchesStateFactory;
        [Inject] private LevelItemsFallingStateFactory levelItemsFallingStateFactory;
        [Inject] private LevelCheckForTurnResultStateFactory levelCheckForTurnResultStateFactory;

        public override void Initialize()
        {
            var idleState = levelIdleStateFactory.Create(this);
            AddState(levelClearStateFactory.Create(this));
            AddState(idleState);
            AddState(levelSpawnStateFactory.Create(this));
            AddState(levelPlayerActionStateFactory.Create(this));
            AddState(levelDestroyingMatchesStateFactory.Create(this));
            AddState(levelItemsFallingStateFactory.Create(this));
            AddState(levelCheckForTurnResultStateFactory.Create(this));

            base.Initialize(idleState);
        }

        private void AddState<T>(T levelState) where T : LevelState
        {
            levelStates[typeof(T)] = levelState;
        }

        public void SetState<T>() where T : LevelState
        {
            if (levelStates.TryGetValue(typeof(T), out var state))
            {
                SetState(state);
            }
        }
    }
}