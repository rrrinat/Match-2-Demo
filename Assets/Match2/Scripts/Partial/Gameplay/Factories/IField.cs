using System.Collections.Generic;
using Match2.Partial.Gameplay.Entities;
using UnityEngine;

namespace Match2.Partial.Gameplay.Factories
{
    public interface IField
    {
        ICell[,] Cells { get; }
        IList<IItem> Items { get; }
        Vector2Int Size { get; }
        
        void Initialize();
    }
}