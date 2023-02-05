using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Match2.Partial.UI.Factories
{
    public interface ILevelFrameFactory
    {
        UniTask<LevelFrame> Create(RectTransform parent, int levelIndex);
    }
}