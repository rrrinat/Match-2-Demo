using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Match2.Common.UI.Windows.Configs;
using UnityEngine;

namespace Match2.Common.UI.Windows.Transitions
{
    public class FadeWindowTransition : IWindowTransition
{
        private readonly CanvasGroup canvasGroup;
        private readonly FadeTransitionConfig config;
        private readonly RectTransform rectTransform;

        private TweenerCore<float, float, FloatOptions> fadeTween;

        private float startAlpha;

        private float startScale;
        private float targetAlpha;
        private float targetScale;

        private float CurrentValue { get; set; }

        public FadeWindowTransition(RectTransform rectTransform, FadeTransitionConfig config, CanvasGroup canvasGroup)
        {
            this.rectTransform = rectTransform;
            this.config = config;
            this.canvasGroup = canvasGroup;
        }

        void IWindowTransition.Show(TweenCallback callback)
        {
            CurrentValue = 0f;

            startAlpha = config.FadeInStartAlpha;
            targetAlpha = 1f;

            startScale = config.StartShowScale;
            targetScale = 1f;

            DoFade(callback);
        }

        void IWindowTransition.Hide(TweenCallback callback)
        {
            CurrentValue = 0f;

            startAlpha = 1f;
            targetAlpha = config.FadeOutEndAlpha;

            startScale = 1f;
            targetScale = config.TargetHideScale;

            DoFade(callback);
        }

        private void DoFade(TweenCallback onComplete)
        {
            if (fadeTween is { active: true }) fadeTween.Kill();

            SetCurrentFadeValue(GetCurrentFadeValue());
            fadeTween = DOTween.To(GetCurrentFadeValue, SetCurrentFadeValue, 1f, config.AnimationDuration)
                .SetUpdate(true)
                .SetEase(config.Ease)
                .OnComplete(onComplete)
                .Play();
        }

        private float GetCurrentFadeValue()
        {
            return CurrentValue;
        }

        private void SetCurrentFadeValue(float value)
        {
            CurrentValue = value;
            if (canvasGroup)
            {
                canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, CurrentValue);
            }
            if (rectTransform)
            {
                rectTransform.localScale = Vector3.one * Mathf.Lerp(startScale, targetScale, CurrentValue);
            }
        }

        public void Skip()
        {
            fadeTween?.Complete();
        }        
        
        void IWindowTransition.Destroy()
        {
            if (fadeTween is { active: true }) fadeTween.Kill();
        }
    }
}
