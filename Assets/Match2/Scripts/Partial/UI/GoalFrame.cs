using Match2.Common.Property;
using Match2.Partial.Gameplay.Static;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Match2.Partial.UI
{
    public class GoalFrame : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private TextMeshProUGUI text;
        
        private ObservablePropertyInt currentCurrencyProperty;

        private GoalData currentGoalData;
        
        public void Initialize(GoalData goalData, Sprite sprite)
        {
            this.currentGoalData = goalData;
            this.image.sprite = sprite;
            
            SubscribeToProperty();
        }

        private void OnDestroy()
        {
            UnsubscribeFromProperty();
        }

        // private void OnEnable()
        // {
        //     SubscribeToProperty();
        // }
        //
        // private void OnDisable()
        // {
        //     UnsubscribeFromProperty();
        // }

        private void SubscribeToProperty()
        {
            currentCurrencyProperty = currentGoalData.Amount;
            
            currentCurrencyProperty.AddListener(OnPropertyChange);
            OnPropertyChange(0, currentCurrencyProperty.Value);
        }

        private void UnsubscribeFromProperty() => currentCurrencyProperty?.RemoveListener(OnPropertyChange);

        protected virtual void OnPropertyChange(int from, int to)
        {
            text.text = to.ToString();
        }
    }
}