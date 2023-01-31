using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Match2.Partial.Gameplay.Enums;
using Match2.Partial.Gameplay.Factories;
using Match2.Partial.Gameplay.Level;
using Match2.Partial.Gameplay.Static;
using UnityEngine;
using VContainer;

namespace Match2.Partial.Gameplay.Entities
{
    public class Field : IField
    {
        [Inject] private LevelData currentLevelData;
        [Inject] private ICellFactory cellFactory;
        [Inject] private IItemFactory itemFactory;

        [Inject] private ItemsMatch itemsMatch;
        [Inject] private ItemsFall itemsFall;

        private Vector2Int size;
        private ICell[,] cells;
        private IList<IItem> items;

        private GameObject fieldView;

        public ICell[,] Cells => cells;
        public IList<IItem> Items => items;
        public Vector2Int Size => size;
        
        public void Initialize()
        {
            fieldView = new GameObject("FieldView");
            
            var cellsData = currentLevelData.CellsData;
            size.x = cellsData.GetLength(0);
            size.y = cellsData.GetLength(1);
            
            CreateCells();
            CreateItems().Forget();
            
            itemsMatch.Initialize(this);
            itemsFall.Initialize(this);
        }

        private void CreateCells()
        {
            var cellsData = currentLevelData.CellsData;
            
            cells = new ICell[size.x, size.y];
            for (int y = 0; y < size.y; y++)
            {
                for (int x = 0; x < size.x; x++)
                {
                    var cellType = cellsData[x, y];
                    cells[x, y] = cellFactory.Create(cellType, fieldView.transform, new Vector2Int(x, y));
                }
            }
        }
        
        private async UniTaskVoid CreateItems()
        {
            var itemsData = currentLevelData.ItemsData;
            
            items = new List<IItem>();
            for (int y = 0; y < size.y; y++)
            {
                for (int x = 0; x < size.x; x++)
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

                    var itemData = itemsData[x, y];
                    var item = await itemFactory.Create(itemData, currentCell);
                    items.Add(item);
                }
            }          
        }
        

    }
}
