using Match2.Common.UI.Windows;
using Match2.Partial.Gameplay.GameStates;
using Match2.Partial.Gameplay.GameStates.States;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Match2.Partial.UI.Windows
{
    public class MainMenuWindow : WindowBase
    {
        [Inject] private GameStateMachine gameStateMachine;

        [SerializeField] private Button changeStateButton;
        
        public void Start()
        {
            changeStateButton.onClick.AddListener(() =>
            {
                gameStateMachine.SetState<GameSelectLevelState>();
                Close();
            });
        }
    }
}
