using Cysharp.Threading.Tasks;
using Match2.Common.Property;
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

        private ObservablePropertyInt currentMovesProperty;
        
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
            
            SubscribeToProperty(levelData.MovesCount);
        }
        
        private void SubscribeToProperty(ObservablePropertyInt property)
        {
            currentMovesProperty = property;
            
            currentMovesProperty.AddListener(OnPropertyChange);
            OnPropertyChange(0, currentMovesProperty.Value);
        }

        private void UnsubscribeFromProperty() => currentMovesProperty?.RemoveListener(OnPropertyChange);
        
        protected virtual void OnPropertyChange(int from, int to)
        {
            movesText.text = to.ToString();
        }

        private async void OnSettingsButton()
        {
            await windowPresenter.ShowAsync<CheatsWindow>();
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            
            UnsubscribeFromProperty();
        }
    }
}
