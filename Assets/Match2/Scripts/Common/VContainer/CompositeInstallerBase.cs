using System.Collections.Generic;
using VContainer;
using VContainer.Unity;

namespace Match2.Common.VContainer
{
    public abstract class CompositeInstallerBase : IInstaller
    {
        public void Install(IContainerBuilder builder)
        {
            foreach (var installer in GetInstallers())
            {
                installer.Install(builder);
            }
        }
        
        protected abstract IReadOnlyList<IInstaller> GetInstallers();
    }
}