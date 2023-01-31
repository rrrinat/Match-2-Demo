using Match2.Partial.Gameplay.Entities;
using UnityEngine;

namespace Match2.Partial.Gameplay.InputProcessor
{
    public class BasicInputController : MonoBehaviour
    {
        [SerializeField]
        private LayerMask cellLayerMask;
        
        private Camera camera;
        private Collider2D[] colliders;

        private void Awake()
        {
            camera = Camera.main;
            colliders = new Collider2D[5];
        }
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 inputPosition = camera.ScreenToWorldPoint(Input.mousePosition);

                var cellView = Select(inputPosition);
                cellView?.OnCellClicked();
            }
        }
      
        private ICellView Select(Vector2 position)
        {
            var count = Physics2D.OverlapPointNonAlloc(position, colliders, cellLayerMask);
            if (count == 0)
            {
                return null;
            }
            foreach (var collider in colliders)
            {
                var cellView = collider.GetComponent<ICellView>();
                if (cellView != null)
                {
                    return cellView;
                }
            }

            return null;
        } 
    }
}
