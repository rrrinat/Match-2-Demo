using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Match2.Partial.UI
{
    public class SpriteFrame : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private TextMeshProUGUI text;

        public void SetLabel(string label)
        {
            text.text = label;
        }
        
        public void SetSprite(Sprite sprite)
        {
            image.sprite = sprite;
        }
    }
}