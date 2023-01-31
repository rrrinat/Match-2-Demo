using Match2.Partial.Gameplay.Factories;
using Match2.Partial.Gameplay.Static;
using Match2.Partial.Loading;
using VContainer;
using VContainer.Unity;

namespace Match2.Partial.Installers
{
    public class MainInstaller : IInstaller
    {
        public void Install(IContainerBuilder builder)
        {
            builder.Register<ICellTypeConverter, CellTypeConverter>(Lifetime.Scoped);
            builder.Register<IStaticDataProvider, DefaultStaticDataProvider>(Lifetime.Scoped);
            builder.Register<SceneLoader>(Lifetime.Scoped);
            builder.Register<LevelLoader>(Lifetime.Scoped);
        }
    }
}