using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Match2.Common.VContainer
{
    public abstract class UnityBehaviourCompositeInstallerBase : MonoBehaviour, IInstaller
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
