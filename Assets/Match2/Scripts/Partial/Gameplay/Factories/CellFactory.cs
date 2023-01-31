using Match2.Partial.Gameplay.Entities;
using Match2.Partial.Gameplay.Enums;
using UnityEngine;
using VContainer;

namespace Match2.Partial.Gameplay.Factories
{
    public class CellFactory : ICellFactory
    {
        private IObjectResolver container;
        
        public CellFactory(IObjectResolver container)
        {
            this.container = container;
        }
        
        public ICell Create(CellType cellType, Transform parent, Vector2Int coord)
        {
            var cell = new Cell();
            container.Inject(cell);
            
            cell.Initialize(cellType, coord, parent);

            return cell;
        }
    }
}