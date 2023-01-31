using Match2.Partial.Gameplay.Enums;
using UnityEngine;

namespace Match2.Partial.Gameplay.Entities
{
    public interface ICell
    {
        public CellType Type { get; }
        public CellState State { get; set; }
        Vector2Int Coord { get; }
        IItem Child { get; }
        bool HasChild { get; }
        bool IsInteractable { get; }
        bool CanBeFalled { get; }
        bool IsMatched(ICell otherCell);
        Transform transform { get; }
        Vector3 Position { get; }
        void Initialize(CellType type, Vector2Int coord, Transform parent);
        void SetChild(IItem item);
        void ReleaseChild();
    }
}