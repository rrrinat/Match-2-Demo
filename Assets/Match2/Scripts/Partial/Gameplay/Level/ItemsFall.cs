using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Match2.Partial.Gameplay.Entities;
using Match2.Partial.Gameplay.Enums;
using Match2.Partial.Gameplay.Factories;
using Match2.Partial.Gameplay.Static;
using UnityEngine;
using VContainer;

namespace Match2.Partial.Gameplay.Level
{
    public class ItemsFall
    {
        [Inject] private LevelData currentLevelData;
        [Inject] private IItemFactory itemFactory;
        
        private Vector2Int fieldSize;
        private ICell[,] cells;
        
        private Queue<List<IItem>> selectedItemsQueue;

        public ItemsFall()
        {
            selectedItemsQueue = new Queue<List<IItem>>();
        }
        
        public void Initialize(IField field)
        {
            fieldSize = field.Size;
            cells = field.Cells;
        }
        
        public async UniTask Fall()
        {
            Select(cells);

            if (selectedItemsQueue.Count > 1)
            {
                return;
            }

            if (selectedItemsQueue.Count == 0)
            {
                return;
            }           
            
            var processedItems = selectedItemsQueue.Dequeue();
            foreach (var currentItem in processedItems)
            {
                currentItem.Fall();
            }
        }
        
        private void Select(ICell[,] cells)
        {
            var xSize = cells.GetLength(0);
            var ySize = cells.GetLength(1);
            
            var selectedItems = new List<IItem>();
            for (int x = 0; x < xSize; x++)
            {
                for (int y = 0; y < ySize; y++)
                {
                    var currentCell = cells[x, y];
                    if (currentCell.Type != CellType.Default)
                    {
                        continue;
                    }
                    
                    if (currentCell.State == CellState.Blocked)
                    {
                        continue;
                    }

                    if (currentCell.HasChild)
                    {
                        continue;
                    }
                    //so... currentCell is empty
                    
                    var fromCell = GetSuitableCellUpwards(currentCell);
                    if (fromCell == null)
                    {
                        continue;
                    }
                    var item = fromCell.Child;
                    
                    fromCell.ReleaseChild();
                    item.SetTarget(currentCell);
                    
                    selectedItems.Add(item);
                }
            }
            if (selectedItems.Count == 0)
            {
                return;
            }
            selectedItemsQueue.Enqueue(selectedItems);
        }
        
        private ICell GetSuitableCellUpwards(ICell toCell)
        {
            var commonItemsData = currentLevelData.CommonItemsData;
            var randomItemData = commonItemsData[Random.Range(0, commonItemsData.Count)];
            
            var coord = toCell.Coord;

            for (int y = coord.y + 1; y < fieldSize.y; y++)
            {
                var fromCell = cells[coord.x, y];
                if (fromCell.Type == CellType.Obstacle)
                {
                    continue;
                }

                if (fromCell.State == CellState.Blocked)
                {
                    continue;
                }

                if (fromCell.CanBeFalled)
                {
                    return fromCell;
                }

                if (fromCell.Type == CellType.SpawnPoint)
                {
                    //var itemData = itemsData[coord.x, y];
                    var item = itemFactory.Create(randomItemData, fromCell);
                    
                    return fromCell;
                }
            }

            return null;
        }
    }
}
