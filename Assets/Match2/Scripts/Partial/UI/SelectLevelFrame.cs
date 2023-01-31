using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Match2.Partial.UI
{
    public class SelectLevelFrame : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI label;

        private Button button;
        public RectTransform RectTransform { get; private set; }

        public void Initialize()
        {
            RectTransform = GetComponent<RectTransform>();
            button = GetComponent<Button>();
        }
        
        public void SetLabel(string text)
        {
            this.label.text = text;
        }

        public void AddListener(UnityAction action)
        {
            button.onClick.AddListener(action);
        }
    }
}
