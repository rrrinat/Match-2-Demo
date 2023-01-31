using System.Collections.Generic;
using Match2.Partial.Gameplay.Enums;
using Match2.Partial.Gameplay.Factories;

namespace Match2.Partial.Gameplay.Static
{
    public class DefaultStaticDataProvider : IStaticDataProvider
    {
        private ICellTypeConverter cellTypeConverter;
        
        public List<LevelData> Levels { get; private set; }
        public Dictionary<int, LevelData> LevelsDictionary { get; private set; }
        
        public DefaultStaticDataProvider(ICellTypeConverter cellTypeConverter)
        {
            this.cellTypeConverter = cellTypeConverter;
            
            Initialize();
        }
        
        private void Initialize()
        {
            var firstLevel = CreateTemporaryLevelData();
            var secondLevel = CreateTemporarySecondLevelData();

            Levels = new List<LevelData>();
            LevelsDictionary = new Dictionary<int, LevelData>();
            
            Levels.Add(firstLevel);
            Levels.Add(secondLevel);
        }
        
        public LevelData CreateTemporaryLevelData()
        {
            var cellsMatrix = CreateTemporaryLevelMatrix();
            var colorMatrix = CreateTemporaryColorMatrix();
            
            var temporaryCellsData = CreateTemporaryCellsData(cellsMatrix);
            var temporaryItemsData = CreateTemporaryItemsData(colorMatrix);
            
            var commonItemsData = CreateCommonItemsData();

            var itemData = new ItemData
            {
                Type = ItemType.Default,
                Color = ItemColor.Red
            };
            
            var firstGoal = new GoalData
            {
                ItemData = itemData,
                Amount = 10
            };
            
            var goals = new List<GoalData> { firstGoal };
            var levelData = new LevelData
            {
                LevelIndex = 1,
                Goals = goals,
                CellsData = temporaryCellsData,
                ItemsData = temporaryItemsData,
                CommonItemsData = commonItemsData
            };

            return levelData;
        }

        private int[,] CreateTemporaryLevelMatrix()
        {
            var matrix = new int[5, 7]
            {
                { 0, 0, 0, 0, 0, 0, 2 },
                { 0, 0, 0, 0, 0, 0, 2 },
                { 0, 0, 1, 0, 0, 0, 2 },
                { 0, 0, 0, 0, 0, 0, 2 },
                { 0, 0, 0, 0, 0, 0, 2 }
            };
            
            return matrix;
        }

        private int[,] CreateTemporaryColorMatrix()
        {
            var matrix = new int[5, 7]
            {
                { 3, 3, 3, 4, 2, 2, 0 },
                { 4, 3, 3, 4, 2, 4, 0 },
                { 2, 4, 0, 4, 2, 4, 0 },
                { 2, 2, 2, 4, 2, 2, 0 },
                { 3, 3, 4, 4, 4, 3, 0 }
            };
            
            return matrix;
        }

        public LevelData CreateTemporarySecondLevelData()
        {
            var cellsMatrix = CreateTemporarySecondLevelMatrix();
            var colorMatrix = CreateTemporarySecondColorMatrix();
            
            var temporaryCellsData = CreateTemporaryCellsData(cellsMatrix);
            var temporaryItemsData = CreateTemporaryItemsData(colorMatrix);
            
            var commonItemsData = CreateCommonItemsData();

            var itemData = new ItemData
            {
                Type = ItemType.Default,
                Color = ItemColor.Blue
            };
            
            var firstGoal = new GoalData
            {
                ItemData = itemData,
                Amount = 5
            };
            
            var goals = new List<GoalData> { firstGoal };
            var levelData = new LevelData
            {
                LevelIndex = 2,
                Goals = goals,
                CellsData = temporaryCellsData,
                ItemsData = temporaryItemsData,
                CommonItemsData = commonItemsData
            };

            return levelData;
        }
        
        private int[,] CreateTemporarySecondLevelMatrix()
        {
            var matrix = new int[5, 7]
            {
                { 0, 0, 0, 0, 0, 0, 2 },
                { 0, 0, 0, 1, 0, 0, 2 },
                { 0, 0, 0, 0, 1, 0, 2 },
                { 0, 0, 0, 0, 0, 0, 2 },
                { 0, 0, 0, 0, 0, 0, 2 }
            };
            
            return matrix;
        }
        
        private int[,] CreateTemporarySecondColorMatrix()
        {
            var matrix = new int[5, 7]
            {
                { 3, 4, 3, 4, 2, 3, 0 },
                { 4, 3, 3, 0, 2, 4, 0 },
                { 2, 4, 2, 4, 0, 4, 0 },
                { 2, 2, 2, 4, 2, 2, 0 },
                { 2, 3, 4, 4, 4, 3, 0 }
            };
            
            return matrix;
        }
        
        private CellType[,] CreateTemporaryCellsData(int[,] matrix)
        {
            var cellsData = new CellType[5, 7];
            
            for (int y = 0; y < matrix.GetLength(1); y++)
            {
                for (int x = 0; x < matrix.GetLength(0); x++)
                {
                    var currentValue = matrix[x, y];
                    cellsData[x, y] = cellTypeConverter.Create(currentValue);
                }
            }
            
            return cellsData;
        }

        private ItemData[,] CreateTemporaryItemsData(int[,] matrix)
        {
            var itemsData = new ItemData[5, 7];
            for (int y = 0; y < matrix.GetLength(1); y++)
            {
                for (int x = 0; x < matrix.GetLength(0); x++)
                {
                    var currentValue = matrix[x, y];
                    if (currentValue == 0)
                    {
                        continue;
                    }
                    
                    var currentItemData = new ItemData
                    {
                        Color = (ItemColor)currentValue,
                        Type = ItemType.Default
                    };
                    itemsData[x, y] = currentItemData;
                }
            }

            return itemsData;
        }

        private List<ItemData> CreateCommonItemsData()
        {
            var itemsData = new List<ItemData>
            {
                new ItemData { Color = ItemColor.Red, Type = ItemType.Default},
                new ItemData { Color = ItemColor.Blue, Type = ItemType.Default},
                new ItemData { Color = ItemColor.Green, Type = ItemType.Default},
            };

            return itemsData;
        }
    }
}
