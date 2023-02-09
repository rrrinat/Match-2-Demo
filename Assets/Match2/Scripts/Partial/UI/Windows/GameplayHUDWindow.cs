using Cysharp.Threading.Tasks;
using Match2.Common.UI.Windows;
using Match2.Partial.Gameplay.Static;
using Match2.Partial.UI.Factories;
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

        public override void Initialize()
        {
            base.Initialize();

            settingsButton.onClick.AddListener(OnSettingsButton);
        }

        public void SetData(LevelData levelData, IGoalFrameFactory goalFrameFactory)
        {
            var goals = levelData.Goals;
            foreach (var goalData in goals.Values)
            {
                goalFrameFactory.Create(goalData, goalsHolder).Forget();
            }
            
            SetMoves(levelData.MovesCount);
        }
        
        private void SetMoves(int number)
        {
            movesText.text = number.ToString();
        }

        private async void OnSettingsButton()
        {
            await windowPresenter.ShowAsync<CheatsWindow>();
        }
    }
}
