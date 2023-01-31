using UnityEngine;

namespace Match2.Partial.Messages
{
    public struct OnCellClickedMessage
    {
        public Vector2Int Coord;
        
        public OnCellClickedMessage(Vector2Int coord)
        {
            this.Coord = coord;
        }
    }
}