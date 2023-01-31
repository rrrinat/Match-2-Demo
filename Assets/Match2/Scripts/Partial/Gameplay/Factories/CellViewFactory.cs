using Cysharp.Threading.Tasks;
using Match2.Partial.Gameplay.Entities;
using Match2.Partial.Gameplay.Enums;
using Match2.Partial.Gameplay.Utils;
using UnityEngine;
using UnityEngine.AddressableAssets;
using VContainer;

namespace Match2.Partial.Gameplay.Factories
{
    public class CellViewFactory : ICellViewFactory
    {
        [Inject] private ICellPositionCalculator positionCalculator;
        [Inject] private IObjectResolver container;
        
        public async UniTask<ICellView> Create(CellType cellType, Vector2Int coord, Transform parent)
        {
            var instance = await Addressables.InstantiateAsync(cellType.ToString());
            instance.name = $"{cellType} Cell [{coord.x}, {coord.y}]";
            instance.transform.SetParent(parent, false);
            instance.transform.position = positionCalculator.CoordToLocalPosition(coord);  

            var cellView = instance.GetComponent<ICellView>();
            cellView.Initialize(coord);
            container.Inject(cellView);

            return cellView;
        }
        
    }
}