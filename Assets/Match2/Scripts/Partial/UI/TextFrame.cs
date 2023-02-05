using TMPro;
using UnityEngine;

namespace Match2.Partial.UI
{
    public class TextFrame : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        
        public void SetLabel(string label)
        {
            text.text = label;
        }
    }
}