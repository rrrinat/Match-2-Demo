using Match2.Partial.Gameplay;
using Match2.Partial.Installers.Composite;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Match2.Partial.Scopes
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private DefaultUnityBehaviorCompositeInstaller defaultUnityBehaviorCompositeInstaller;
        
        protected override void Configure(IContainerBuilder builder)
        {
            defaultUnityBehaviorCompositeInstaller.Install(builder);

            var simpleCompositeInstaller = new SimpleCompositeInstaller();
            simpleCompositeInstaller.Install(builder);
            
            builder.RegisterEntryPoint<MainMenuEntryPoint>(Lifetime.Singleton);
        }
    }
}