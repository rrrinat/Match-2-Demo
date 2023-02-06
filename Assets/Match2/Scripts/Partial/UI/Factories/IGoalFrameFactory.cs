using Cysharp.Threading.Tasks;
using Match2.Partial.Gameplay.Static;
using UnityEngine;

namespace Match2.Partial.UI.Factories
{
    public interface IGoalFrameFactory
    {
        UniTask<SpriteFrame> Create(GoalData data, RectTransform parent);
    }
}