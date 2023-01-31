using Match2.Partial.Gameplay.Enums;
using Match2.Partial.Messages;
using MessagePipe;
using UnityEngine;
using VContainer;

namespace Match2.Partial.Gameplay.Entities
{
    public class CellView : MonoBehaviour, ICellView
    {
        [Inject] readonly IPublisher<OnCellClickedMessage> publisher;
        
        private CellType cellType;
        private Vector2Int coord;
        
        public void Initialize(Vector2Int coord)
        {
            this.coord = coord;
        }

        public void OnCellClicked()
        {
            publisher.Publish(new OnCellClickedMessage(coord));
        }
    }
}
