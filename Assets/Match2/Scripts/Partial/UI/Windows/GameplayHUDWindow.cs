using Match2.Common.UI.Windows;
using Match2.Partial.Gameplay.Static;
using Match2.Partial.UI.Factories;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Match2.Partial.UI.Windows
{
    public class GameplayHUDWindow : WindowBase
    {
        [SerializeField] private Button settingsButton;
        [SerializeField] private RectTransform goalsHolder;
        [SerializeField] private TextMeshProUGUI movesText;

        [Inject] private IGoalFrameFactory goalFrameFactory;
        
        public void SetData(LevelData levelData)
        {
            foreach (var goal in levelData.Goals)
            {
                goalFrameFactory.Create(goal, goalsHolder);
            }
        }
        
        public void SetMoves(int number)
        {
            movesText.text = number.ToString();
        }

        public void AddGoalFrame(GoalData goalData)
        {
            
        }
    }
}
