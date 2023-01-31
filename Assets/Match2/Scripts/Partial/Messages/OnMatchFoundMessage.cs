using System.Collections.Generic;
using Match2.Partial.Gameplay.Entities;

namespace Match2.Partial.Messages
{
    public class OnMatchFoundMessage
    {
        public HashSet<ICell> Cells;
        public OnMatchFoundMessage(HashSet<ICell> cells)
        {
            this.Cells = cells;
        }
    }
}