using Cysharp.Threading.Tasks;
using Match2.Partial.Gameplay.Enums;

namespace Match2.Partial.Gameplay.Entities
{
    public interface IItem
    {
        ItemType Type { get; }
        ItemColor Color { get; }
        ItemState State { get; }
        bool IsMatched(IItem item);
        UniTask CreateView();
        UniTask Destroy();
        UniTask Fall();
        void SetParent(ICell parent);
        void SetTarget(ICell cell);
        void Sort();
        void Decline();
    }
}