using Match2.Partial.Gameplay.Level.LevelStates;
using Match2.Partial.Gameplay.Level.LevelStates.Factories;
using VContainer;
using VContainer.Unity;

namespace Match2.Partial.Installers
{
    public class LevelStateFactoriesInstaller : IInstaller
    {
        public void Install(IContainerBuilder builder)
        {
            builder.Register<LevelStateMachine>(Lifetime.Singleton);
            
            builder.Register<LevelClearStateFactory>(Lifetime.Scoped);
            builder.Register<LevelIdleStateFactory>(Lifetime.Scoped);
            builder.Register<LevelSpawnStateFactory>(Lifetime.Scoped);
            builder.Register<LevelPlayerActionStateFactory>(Lifetime.Scoped);
            builder.Register<LevelDestroyingMatchesStateFactory>(Lifetime.Scoped);
            builder.Register<LevelItemsFallingStateFactory>(Lifetime.Scoped);
            builder.Register<LevelCheckForTurnResultStateFactory>(Lifetime.Scoped);
        }
    }
}