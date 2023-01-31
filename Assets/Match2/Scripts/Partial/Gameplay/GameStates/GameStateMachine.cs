using System;
using System.Collections.Generic;
using Match2.Common.StateMachine;
using Match2.Partial.Gameplay.GameStates.Factories;
using Match2.Partial.Gameplay.GameStates.States;
using VContainer;

namespace Match2.Partial.Gameplay.GameStates
{
    public class GameStateMachine : StateMachine
    {
        private readonly Dictionary<Type, GameState> gameStates = new Dictionary<Type, GameState>();

        [Inject] private GameIdleStateFactory gameIdleStateFactory;
        [Inject] private GameForwardStateFactory gameForwardStateFactory;
        [Inject] private GameSelectLevelStateFactory gameSelectLevelStateFactory;
        [Inject] private GameLevelCreationStateFactory gameLevelCreationStateFactory;
        [Inject] private GameLevelSpawnStateFactory gameLevelSpawnStateFactory;
        [Inject] private GameLevelClearStateFactory gameLevelClearStateFactory;
        
        public override void Initialize()
        {
            var idleState = gameIdleStateFactory.Create(this);
            AddState(idleState);
            AddState(gameForwardStateFactory.Create(this));
            AddState(gameSelectLevelStateFactory.Create(this));
            AddState(gameLevelCreationStateFactory.Create(this));
            AddState(gameLevelSpawnStateFactory.Create(this));
            AddState(gameLevelClearStateFactory.Create(this));

            base.Initialize(idleState);
        }
        
        private void AddState<T>(T gameState) where T : GameState
        {
            gameStates[typeof(T)] = gameState;
        }

        public void SetState<T>() where T : GameState
        {
            if (gameStates.TryGetValue(typeof(T), out var state))
            {
                SetState(state);
            }
        }
    }
}
