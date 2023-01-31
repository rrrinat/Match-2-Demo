using System.Collections.Generic;
using Match2.Partial.Gameplay.Enums;

namespace Match2.Partial.Gameplay.Static
{
    public class LevelData
    {
        public int CellSize = 1;
        public int LevelIndex;
        public List<GoalData> Goals;
        public CellType[,] CellsData;
        public ItemData[,] ItemsData;
        
        public List<ItemData> CommonItemsData;
    }
}
