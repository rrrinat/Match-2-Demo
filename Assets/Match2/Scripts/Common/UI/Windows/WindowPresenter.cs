using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using VContainer;
using VContainer.Unity;

namespace Match2.Common.UI.Windows
{
    public class WindowPresenter : MonoBehaviour
{
        [Inject] private WindowsContainer windowsContainer;
        [Inject] private IObjectResolver container;

        public async UniTask<T> ShowAsync<T>() where T : WindowBase
        {
            var window = await ShowInternal<T>();

            windowsContainer.Add(window);
            window.Show();

            return window;
        }

        private async UniTask<T> ShowInternal<T>() where T : WindowBase
        {
            var type = typeof(T);
            var hashCode = type.GetHashCode();
        
            if (windowsContainer.TryGetWindow(hashCode, out var windowBase))
            {
                return windowBase as T;
            }

            var instance = await Addressables.InstantiateAsync(type.Name);
            var window = instance.GetComponent<WindowBase>() as T;

            if (window == null)
            {
                Debug.LogError($"Couldn't cast {window} as {type.Name}");
                
                return null;
            }

            container.InjectGameObject(instance);

            return window;
        }       
        
        public void Close(WindowBase window)
        {
            windowsContainer.Remove(window);
        }

        public void OnClosed(WindowBase window)
        {
            if (!Addressables.ReleaseInstance(window.gameObject))
            {
                GameObject.Destroy(window.gameObject);
            }
        }

        public void TryClose<T>() where T : WindowBase
        {
            if (windowsContainer.TryGetWindow(out T window))
            {
                window.Close();
            }
        }
    }
}
