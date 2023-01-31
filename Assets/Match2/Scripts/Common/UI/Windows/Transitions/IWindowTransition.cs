using DG.Tweening;

namespace Match2.Common.UI.Windows.Transitions
{
    public interface IWindowTransition
    {
        void Show(TweenCallback onShow);
        void Hide(TweenCallback onClose);
        void Destroy();
    }
}
