using Cysharp.Threading.Tasks;
using Match2.Partial.Gameplay.Entities;
using Match2.Partial.Gameplay.Enums;
using UnityEngine;

namespace Match2.Partial.Gameplay.Factories
{
    public interface ICellViewFactory
    {
        UniTask<ICellView> Create(CellType cellType, Vector2Int coord, Transform parent);
    }
}