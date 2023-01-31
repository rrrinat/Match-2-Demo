using Match2.Partial.Gameplay.Enums;
using Match2.Partial.Gameplay.Factories;
using UnityEngine;
using VContainer;

namespace Match2.Partial.Gameplay.Entities
{
    public class Cell : ICell
    {
        [Inject] private ICellViewFactory cellViewFactory;
        
        private CellType type;

        private ICellView view;
        private IItem child;
        
        private Vector2Int coord;

        public Transform transform => view.transform;
        public Vector3 Position => view.transform.position;
        public bool HasChild => child != null;
        public IItem Child => child;
        public Vector2Int Coord => coord;
        public CellType Type => type;
        public CellState State { get; set; }

        public bool IsInteractable
        {
            get
            {
                if (Type != CellType.Default)
                {
                    return false;
                }

                if (State == CellState.Blocked)
                {
                    return false;
                }          
            
                if (!HasChild)
                {
                    return false;
                }
            
                return true;
            }
        }
        
        public bool CanBeFalled
        {
            get
            {
                if (Type != CellType.Default)
                {
                    return false;
                }

                if (!HasChild)
                {
                    return false;
                }
                
                if (Child.State != ItemState.Default)
                {
                    return false;
                }
                return true;
            }
        }
        
        public async void Initialize(CellType type, Vector2Int coord, Transform parent)
        {
            this.type = type;
            this.coord = coord;

            this.view = await cellViewFactory.Create(type, coord, parent);

        }
        
        public void SetChild(IItem item)
        {
            if (this.child != null)
            {
                Debug.LogError("Can not create chip in non empty cell");
                return;
            }
            
            this.child = item;
            
            item.SetParent(this);
        }
        
        public void ReleaseChild()
        {
            if (child == null)
            {
                return;
            }

            child = null;
            State = CellState.Default;           
        }
        
        public bool IsMatched(ICell otherCell)
        {
            return child.IsMatched(otherCell.Child);
        }   
    }
}
