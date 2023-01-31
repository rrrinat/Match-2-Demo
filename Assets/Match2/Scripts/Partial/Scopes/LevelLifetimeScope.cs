﻿using Match2.Partial.Gameplay.Factories;
using Match2.Partial.Gameplay.Level;
using Match2.Partial.Gameplay.Utils;
using Match2.Partial.Gameplay.VFX;
using Match2.Partial.Installers;
using VContainer;
using VContainer.Unity;

namespace Match2.Partial.Scopes
{
    public class LevelLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            var levelStateFactoriesInstaller = new LevelStateFactoriesInstaller();
            levelStateFactoriesInstaller.Install(builder);
            
            builder.Register<ICellPositionCalculator, CellPositionCalculator>(Lifetime.Scoped);
            builder.Register<ICellFactory, CellFactory>(Lifetime.Scoped);
            builder.Register<ICellViewFactory, CellViewFactory>(Lifetime.Scoped);
            builder.Register<IItemFactory, ItemFactory>(Lifetime.Scoped);
            builder.Register<IItemViewFactory, ItemViewFactory>(Lifetime.Scoped);
            builder.Register<IFieldFactory, FieldFactory>(Lifetime.Scoped);
            
            builder.Register<ItemDestroyPoolCollection>(Lifetime.Scoped);
            
            builder.Register<ItemsMatch>(Lifetime.Scoped);
            builder.Register<ItemsFall>(Lifetime.Scoped);
            
            builder.RegisterEntryPoint<LevelEntry>();
        }
    }
}