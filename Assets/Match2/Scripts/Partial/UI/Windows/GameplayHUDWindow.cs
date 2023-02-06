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

        [Inject] private WindowPresenter windowPresenter;
        [Inject] private IGoalFrameFactory goalFrameFactory;

        public override void Initialize()
        {
            base.Initialize();

            settingsButton.onClick.AddListener(OnSettingsButton);
        }

        public void SetData(LevelData levelData)
        {
            foreach (var goal in levelData.Goals)
            {
                goalFrameFactory.Create(goal, goalsHolder);
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
