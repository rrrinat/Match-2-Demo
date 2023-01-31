using Match2.Common.UI.Windows;
using Match2.Partial.Gameplay.GameStates;
using Match2.Partial.Gameplay.GameStates.States;
using Match2.Partial.Messages;
using MessagePipe;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Match2.Partial.UI.Windows
{
    public class MyFirstWindow : WindowBase
    {
        //[Inject] readonly IPublisher<int> publisher;
        [Inject] private GameStateMachine gameStateMachine;

        [SerializeField] private Button changeStateButton;
        
        public void Start()
        {
            //this.publisher.Publish(new TestEvent());
            
            //changeStateButton.onClick.AddListener(()=> {this.publisher.Publish(new TestEvent());});
            changeStateButton.onClick.AddListener(() =>
            {
                gameStateMachine.SetState<GameLevelClearState>();
            });
        }
    }
}