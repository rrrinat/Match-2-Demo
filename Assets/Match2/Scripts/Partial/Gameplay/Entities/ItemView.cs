using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Match2.Partial.Gameplay.Entities
{
    public class ItemView : MonoBehaviour, IItemView
    {
        [SerializeField]
        private SpriteRenderer renderer;
        
        public void Initialize(Sprite sprite)
        {
            renderer.sprite = sprite;
        }

        public void Decline()
        {
            var sequence = DOTween.Sequence();
            sequence.Append(transform.DOLocalRotate(new Vector3(0f, 0f, 45f), 0.1f)).
                Append(transform.DOLocalRotate(new Vector3(0f, 0f, -45f), 0.1f)).
                Append(transform.DOLocalRotate(Vector3.zero, 0.1f)).
                Play();
        }
        
        public void SetSortingOrder(int sortingOrder)
        {
            renderer.sortingOrder = sortingOrder;
        }
        
        public void SetParent(CellView parent)
        {
            transform.SetParent(parent.transform);
        }

        public async UniTask Hide()
        {
            var scaleTo = 
                transform.DOScale(Vector3.zero, 0.1f).SetEase(Ease.OutBack);
            await scaleTo.AsyncWaitForCompletion();
        }

        public Tween MoveTo(Vector3 position, float duration)
        {
            var sequence = DOTween.Sequence();
            var moveTo = transform.DOMove(position, duration);
            //.SetEase(Ease.OutBack);
            sequence.Append(moveTo);

            return sequence;
        }
    }
}
