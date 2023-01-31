using Cysharp.Threading.Tasks;
using Match2.Partial.Gameplay.Entities;
using Match2.Partial.Gameplay.Static;
using VContainer;

namespace Match2.Partial.Gameplay.Factories
{
    public class ItemFactory : IItemFactory
    {
        private IObjectResolver container;
        
        public ItemFactory(IObjectResolver container)
        {
            this.container = container;
        }
        
        public async UniTask<IItem> Create(ItemData itemData, ICell parent)
        {
            var item = new Item(itemData);
            container.Inject(item);
            
            parent.SetChild(item);
            await item.CreateView();
            item.Sort();

            return item;
        }
    }
}