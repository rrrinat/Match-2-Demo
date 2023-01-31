using Cysharp.Threading.Tasks;
using Match2.Partial.Gameplay.Entities;
using Match2.Partial.Gameplay.Static;

namespace Match2.Partial.Gameplay.Factories
{
    public interface IItemFactory
    {
        UniTask<IItem> Create(ItemData itemData, ICell parent);
    }
}