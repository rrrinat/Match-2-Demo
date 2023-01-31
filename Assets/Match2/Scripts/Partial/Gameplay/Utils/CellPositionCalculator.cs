using Match2.Partial.Gameplay.Static;
using UnityEngine;

namespace Match2.Partial.Gameplay.Utils
{
    public class CellPositionCalculator : ICellPositionCalculator
    {
        private LevelData currentLevelData;
        private int cellSize;
        private Vector2Int fieldSize;
        
        public CellPositionCalculator(LevelData levelData)
        {
            this.currentLevelData = levelData;
            this.cellSize = levelData.CellSize;

            var cellData = levelData.CellsData;
            var xSize = cellData.GetLength(0);
            var ySize = cellData.GetLength(1);
            
            this.fieldSize = new Vector2Int(xSize, ySize);
        }
        
        public Vector3 CoordToLocalPosition(Vector2Int coord)
        {
            var x = cellSize * (coord.x - 0.5f * (fieldSize.x - 1));
            var y = cellSize * (coord.y - 0.5f * (fieldSize.y - 1));
        
            return new Vector3(x, y);
        } 
    }
}