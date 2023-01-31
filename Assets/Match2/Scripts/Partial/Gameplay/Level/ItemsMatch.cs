using System.Collections.Generic;
using Match2.Partial.Gameplay.Entities;
using Match2.Partial.Gameplay.Enums;
using Match2.Partial.Gameplay.Factories;
using Match2.Partial.Messages;
using MessagePipe;
using UnityEngine;

namespace Match2.Partial.Gameplay.Level
{
    public class ItemsMatch
    {
        private IPublisher<OnMatchFoundMessage> onMatchFoundPublisher;

        private Vector2Int fieldSize;
        private ICell[,] cells;
        
        private int requiredCellsCount = 2;
        
        private Vector2Int[] directions
        {
            get
            {
                return new[]
                {
                    Vector2Int.left,
                    Vector2Int.right,
                    Vector2Int.up,
                    Vector2Int.down
                };               
            }
        }

        public ItemsMatch(IPublisher<OnMatchFoundMessage> onMatchFoundPublisher)
        {
            this.onMatchFoundPublisher = onMatchFoundPublisher;
        }

        public void Initialize(IField field)
        {
            fieldSize = field.Size;
            cells = field.Cells;
        }
        
        public void OnCellClicked(Vector2Int coord)
        {
            var currentCell = cells[coord.x, coord.y];
            if (!currentCell.IsInteractable)
            {
                return;
            }
            var cellEntities = BFS(currentCell);

            if (cellEntities.Count >= requiredCellsCount)
            {
                onMatchFoundPublisher.Publish(new OnMatchFoundMessage(cellEntities));

            }
            else
            {
                currentCell.Child.Decline();
            }
        }
        
        private HashSet<ICell> BFS(ICell start)
        {
            var visited = new HashSet<ICell>();

            var queue = new Queue<ICell>();
            queue.Enqueue(start);
            while (queue.Count > 0)
            {
                var cellEntity = queue.Dequeue();

                if (visited.Contains(cellEntity))
                {
                    continue;
                }

                visited.Add(cellEntity);

                var neighbours = GetNeighbours(cellEntity);
                foreach (var neighbour in neighbours)
                {
                    if (!neighbour.IsInteractable)
                    {
                        continue;
                    }

                    if (neighbour.Child.Type != ItemType.Default)
                    {
                        continue;
                    }
                    
                    if (!neighbour.IsMatched(start))
                    {
                        continue;
                    }
                    
                    if (!visited.Contains(neighbour))
                    {
                        queue.Enqueue(neighbour);
                    }
                }
            }

            return visited;
        }
        
        private List<ICell> GetNeighbours(ICell currentCell)
        {
            var neighbours = new List<ICell>();
            foreach (var direction in directions)
            {
                var checkedCoord = currentCell.Coord + direction;
                if (WithinBoundaries(checkedCoord))
                {
                    var checkedCell = cells[checkedCoord.x, checkedCoord.y];
                    if (checkedCell.Type == CellType.Default)
                    {
                        neighbours.Add(checkedCell);
                    }
                }
            }

            return neighbours;
        }
        
        private bool WithinBoundaries(Vector2Int coord)
        {
            return coord.x >= 0 && coord.x < fieldSize.x &&
                   coord.y >= 0 && coord.y < fieldSize.y;
        }
    }
}
