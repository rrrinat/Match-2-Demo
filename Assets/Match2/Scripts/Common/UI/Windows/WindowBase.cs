using System.Threading.Tasks;
using Match2.Common.UI.Windows.Configs;
using Match2.Common.UI.Windows.Transitions;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Match2.Common.UI.Windows
{
    [RequireComponent(typeof(CanvasGroup), typeof(Canvas), typeof(GraphicRaycaster))]
    public class WindowBase : MonoBehaviour
{
        [SerializeField] private RectTransform animatedRectTransform;
        [SerializeField] private FadeTransitionConfig fadeTransitionConfig;

        protected WindowPresenter windowPresenter;
        protected WindowsContainer windowsContainer;

        protected CanvasGroup canvasGroup;
        
        private IWindowTransition windowTransition;

        public RectTransform RectTransform { get; private set; }

        protected RectTransform TargetRectTransform => animatedRectTransform ? animatedRectTransform : RectTransform;
        
        public virtual void OnDestroy()
        {
            windowTransition?.Destroy();
        }

        [Inject]
        public void Construct(WindowPresenter windowPresenter, WindowsContainer windowsContainer)
        {
            this.windowPresenter = windowPresenter;
            this.windowsContainer = windowsContainer;
        }
        
        public virtual void Initialize()
        {
            RectTransform = GetComponent<RectTransform>();
            RectTransform.localScale = Vector3.zero;

            canvasGroup = GetComponent<CanvasGroup>();
            windowTransition = GetWindowTransition();
        }

        public virtual IWindowTransition GetWindowTransition()
        {
            return new FadeWindowTransition(TargetRectTransform, fadeTransitionConfig, canvasGroup);
        }

        public virtual void Focus()
        {
        }

        public virtual void Defocus()
        {
        }

        public virtual void Show()
        {
            if (!gameObject.activeSelf) gameObject.SetActive(true);
            windowTransition.Show(OnShowingAnimationEnd);
        }

        public void Hide()
        {
            canvasGroup.interactable = false;
            windowTransition.Hide(OnAnimationHide);
        }
        
        private void OnShowingAnimationEnd()
        {
            canvasGroup.interactable = true;
        }
        
        private void OnAnimationHide()
        {
            if (gameObject.activeSelf) gameObject.SetActive(false);
        }

        public virtual void Close()
        {
            if (gameObject == null) return;

            canvasGroup.interactable = false;
            
            windowTransition.Hide(YieldClose);
            windowPresenter.Close(this);
        }
        
        private async void YieldClose()
        {
            await Task.Yield();
            windowPresenter.OnClosed(this);
        }
    }
}
