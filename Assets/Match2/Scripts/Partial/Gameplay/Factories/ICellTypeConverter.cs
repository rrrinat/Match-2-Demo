using Match2.Partial.Gameplay.Enums;

namespace Match2.Partial.Gameplay.Factories
{
    public interface ICellTypeConverter
    {
        CellType Create(int value);
    }
}