using Cysharp.Threading.Tasks;
using Match2.Partial.Gameplay.Entities;
using Match2.Partial.Gameplay.Static;

namespace Match2.Partial.Gameplay.Factories
{
    public interface IItemViewFactory
    {
        UniTask<IItemView> Create(ItemData itemData, ICell parent);
    }
}