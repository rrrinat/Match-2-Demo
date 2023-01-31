using System.Collections.Generic;
using Match2.Common.VContainer;
using VContainer.Unity;

namespace Match2.Partial.Installers.Composite
{
    public class SimpleCompositeInstaller : CompositeInstallerBase
    {
        protected override IReadOnlyList<IInstaller> GetInstallers()
        {
            return new List<IInstaller>
            {
                new MessagePipeInstaller(),
                new MainInstaller(),
                new GameStateFactoriesInstaller()
            };
        }
    }
}