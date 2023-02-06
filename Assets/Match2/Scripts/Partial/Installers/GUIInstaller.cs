using Match2.Common.UI.Windows;
using Match2.Partial.UI.Factories;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Match2.Partial.Installers
{
    public class GUIInstaller : MonoBehaviour, IInstaller
    {
        public void Install(IContainerBuilder builder)
        {
            builder.Register<WindowsContainer>(Lifetime.Singleton);
            builder.Register<WindowPresenter>(Lifetime.Singleton);
            
            builder.Register<ILevelFrameFactory, LevelFrameFactory>(Lifetime.Singleton);
            builder.Register<IGoalFrameFactory, GoalFrameFactory>(Lifetime.Singleton);
        }
    }
}
