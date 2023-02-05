using Match2.Common.UI.Windows;
using Match2.Partial.Gameplay.Static;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Match2.Partial.UI.Windows
{
    public class GameplayHUDWindow : WindowBase
    {
        [SerializeField] private Button settingsButton;
        [SerializeField] private RectTransform goalsHolder;
        [SerializeField] private TextMeshProUGUI movesText;
        
        public void SetMoves(int number)
        {
            movesText.text = number.ToString();
        }

        public void AddGoalFrame(GoalData goalData)
        {
            
        }
    }
}
