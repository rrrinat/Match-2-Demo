using System.Collections.Generic;
using Match2.Partial.Gameplay.Enums;

namespace Match2.Partial.Gameplay.Static
{
    public class LevelData
    {
        public int CellSize = 1;
        public int LevelIndex;
        public int MovesCount;
        public Dictionary<ItemData, GoalData> Goals;
        public CellType[,] CellsData;
        public ItemData[,] ItemsData;
        
        public List<ItemData> CommonItemsData;

        public bool TryGetGoalData(ItemData itemData, out GoalData goalData)
        {
            return Goals.TryGetValue(itemData, out goalData);
        }
    }
}
