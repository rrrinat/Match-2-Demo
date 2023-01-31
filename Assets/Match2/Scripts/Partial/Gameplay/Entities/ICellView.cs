using UnityEngine;

namespace Match2.Partial.Gameplay.Entities
{
    public interface ICellView
    {
        Transform transform { get; }
        void Initialize(Vector2Int coord);
        void OnCellClicked();
    }
}