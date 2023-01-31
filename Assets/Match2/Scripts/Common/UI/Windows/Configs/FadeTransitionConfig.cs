using DG.Tweening;
using UnityEngine;

namespace Match2.Common.UI.Windows.Configs
{
    [CreateAssetMenu(menuName = "Match2/Configs/GUI/Windows/Transitions/FadeTransitionConfig")]
    public class FadeTransitionConfig : ScriptableObject
    {
        [SerializeField] private float fadeDuration = .125f;
        [SerializeField] private float startShowScale = .5f;
        [SerializeField] private float targetHideScale = .5f;
        [SerializeField] private Ease fadeEase = Ease.OutCubic;
        [SerializeField] private float fadeInStartAlpha = 0f;
        [SerializeField] private float fadeOutEndAlpha = 0f;

        public float AnimationDuration => fadeDuration;
        public float StartShowScale => startShowScale;
        public float TargetHideScale => targetHideScale;
        public Ease Ease => fadeEase;
        public float FadeInStartAlpha => fadeInStartAlpha;
        public float FadeOutEndAlpha => fadeOutEndAlpha;
    }
}
