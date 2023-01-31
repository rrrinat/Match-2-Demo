using UnityEngine;

namespace Match2.Common.Extensions
{
    public static class RectTransformExtension
    {
        public static void StretchToParent(this RectTransform rectTransform)
        {
            rectTransform.localScale = Vector3.one;
            rectTransform.anchorMax = Vector2.one;
            rectTransform.anchorMin = Vector2.zero;
            rectTransform.anchoredPosition = Vector2.zero;
            rectTransform.sizeDelta = Vector2.zero;
        }
    }
}
