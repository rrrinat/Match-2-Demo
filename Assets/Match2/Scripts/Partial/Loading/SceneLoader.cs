using Cysharp.Threading.Tasks;
using Match2.Partial.Loading.Enums;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace Match2.Partial.Loading
{
    public class SceneLoader
    {
        private readonly LifetimeScope parent;

        public SceneLoader(LifetimeScope lifetimeScope)
        {
            parent = lifetimeScope;
        }
        
        public async UniTask LoadSceneAsync(SceneType sceneType)
        {
            using (LifetimeScope.EnqueueParent(parent))
            {
                await SceneManager.LoadSceneAsync(sceneType.ToString(), LoadSceneMode.Single);
            }
        }
    }
}