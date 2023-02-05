using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Match2.Partial.UI.Factories
{
    public class LevelFrameFactory : ILevelFrameFactory
    {
        public async UniTask<LevelFrame> Create(RectTransform parent, int levelIndex)
        {
            var instance = await Addressables.InstantiateAsync("LevelFrame");
            var levelFrame = instance.GetComponent<LevelFrame>();
            levelFrame.Initialize();
            levelFrame.RectTransform.SetParent(parent);
            levelFrame.SetLabel(levelIndex.ToString());

            return levelFrame;
        }
    }
}