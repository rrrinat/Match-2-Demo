using Match2.Partial.Gameplay.Entities;
using Match2.Partial.Gameplay.Enums;
using UnityEngine;

namespace Match2.Partial.Gameplay.Factories
{
    public interface ICellFactory
    {
        ICell Create(CellType cellType, Transform container, Vector2Int position);
    }
}