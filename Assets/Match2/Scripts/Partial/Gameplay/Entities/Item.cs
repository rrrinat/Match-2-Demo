using Cysharp.Threading.Tasks;
using DG.Tweening;
using Match2.Partial.Gameplay.Enums;
using Match2.Partial.Gameplay.Factories;
using Match2.Partial.Gameplay.Static;
using Match2.Partial.Gameplay.VFX;
using UnityEngine.AddressableAssets;
using VContainer;

namespace Match2.Partial.Gameplay.Entities
{
    public class Item : IItem
    {
        [Inject] private IItemViewFactory itemViewFactory;
        [Inject] private ItemDestroyPoolCollection itemDestroyPoolCollection;
        
        private ItemData data;
        private ItemState state;
        private IItemView view;
        private ICell parent;
        private ICell target;
        
        public ItemData Data => data;
        public ItemType Type => Data.Type;
        public ItemColor Color => Data.Color;
        public ItemState State => state;
        
        public ICell Parent => parent;
        public ICell Target => target;

        public Item(ItemData data)
        {
            this.data = data;
            this.state = ItemState.Default;
        }
        
        public async UniTask CreateView()
        {
            this.view = await itemViewFactory.Create(data, parent);
        }

        public void Sort()
        {
            var coord = parent.Coord;
            
            int sortingOrder = (100 - coord.y * 5);
            SetSortingOrder(sortingOrder);
        }
        
        private void SetSortingOrder(int sortingOrder)
        {
            view.SetSortingOrder(sortingOrder);
        }
        
        /// <summary>
        /// Вызываем только из функции ICell.SetChild()
        /// </summary>
        /// <param name="parent"></param>
        public void SetParent(ICell parent)
        {
            this.parent = parent;
        }
        
        public async UniTask Fall()
        {
            await FallToInternal(Target);
            ResetCellState(Target);
            Sort();
        }
        
        private async UniTask FallToInternal(ICell toCell)
        {
            this.state = ItemState.FallDown;
            var moveTo = view.MoveTo(toCell.Position, 0.1f);
            
            await moveTo.AsyncWaitForCompletion();
        }
        
        private void ResetCellState(ICell toCell)
        {
            toCell.SetChild(this);
            toCell.State = CellState.Default;
            state = ItemState.Default;
            target = null;
        }  
        
        public void SetTarget(ICell cell)
        {
            this.target = cell;

            cell.State = CellState.Blocked;
            this.state = ItemState.ReadyToFall;
        }
        
        public void Decline()
        {
            this.view.Decline();
        }
        
        public bool IsMatched(IItem item)
        {
            return item.Type == Type && item.Color == Color;
        }
        
        public async UniTask Destroy()
        {
            if (view == null)
            {
                return;
            }

            //await view.Hide();
            
            await DestroyInternal();
        }
        
        private async UniTask DestroyInternal()
        {
            itemDestroyPoolCollection.SpawnEffectAndReturn(Color, view.transform.position);
            Addressables.ReleaseInstance(view.gameObject);

            await UniTask.Delay(30);
            
            parent.ReleaseChild();
        }
    }
}