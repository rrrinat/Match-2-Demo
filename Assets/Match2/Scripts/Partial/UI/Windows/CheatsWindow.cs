using Match2.Common.UI.Windows;
using UnityEngine;
using UnityEngine.UI;

namespace Match2.Partial.UI.Windows
{
    public class CheatsWindow : WindowBase
    {
        [SerializeField] private Button closeButton;

        public override void Initialize()
        {
            base.Initialize();
            
            closeButton.onClick.AddListener(Close);
        }
    }
}
