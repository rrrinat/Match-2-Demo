using Match2.Partial.Gameplay.Enums;

namespace Match2.Partial.Gameplay.Factories
{
    public class CellTypeConverter : ICellTypeConverter
    {
        public CellType Create(int value)
        {
            switch (value)
            {
                case 0: return CellType.Default;
                case 1: return CellType.Obstacle;
                case 2: return CellType.SpawnPoint;
                
                default: return CellType.Default;
                
            }
        }
    }
}