using UnityEngine;
using UnityEngine.EventSystems;
using VContainer;
using VContainer.Unity;

namespace Match2.Partial.Installers
{
    public class CommonSceneObjectsInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private Canvas mainCanvas;
        [SerializeField] private EventSystem eventSystem;
        
        public void Install(IContainerBuilder builder)
        {
            builder.RegisterComponent(mainCamera);
            builder.RegisterComponent(mainCanvas);
            builder.RegisterComponent(eventSystem);
        }
    }
}
