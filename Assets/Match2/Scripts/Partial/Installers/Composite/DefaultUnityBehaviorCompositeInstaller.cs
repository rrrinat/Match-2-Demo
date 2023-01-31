using System.Collections.Generic;
using Match2.Common.VContainer;
using UnityEngine;
using VContainer.Unity;

namespace Match2.Partial.Installers.Composite
{
    public class DefaultUnityBehaviorCompositeInstaller : UnityBehaviourCompositeInstallerBase
    {
        [SerializeField] private CommonSceneObjectsInstaller commonSceneObjectsInstaller;
        [SerializeField] private GUIInstaller guiInstaller;
        
        protected override IReadOnlyList<IInstaller> GetInstallers()
        {
            return new List<IInstaller>
            {
                commonSceneObjectsInstaller,
                guiInstaller
            };
        }
    }
}