using UnityEngine;

namespace Match2.Partial.Gameplay.Utils
{
    public interface ICellPositionCalculator
    {
        Vector3 CoordToLocalPosition(Vector2Int coord);
    }
}