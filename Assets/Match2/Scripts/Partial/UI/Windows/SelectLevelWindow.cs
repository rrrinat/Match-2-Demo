using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Match2.Common.UI.Windows;
using Match2.Partial.Gameplay.GameStates;
using Match2.Partial.Gameplay.Static;
using Match2.Partial.Messages;
using Match2.Partial.UI.Factories;
using MessagePipe;
using UnityEngine;
using UnityEngine.AddressableAssets;
using VContainer;

namespace Match2.Partial.UI.Windows
{
    public class SelectLevelWindow : WindowBase
    {
        [SerializeField] private RectTransform holder;

        [Inject] private GameStateMachine gameStateMachine;
        [Inject] private IStaticDataProvider staticDataProvider;
        [Inject] readonly IPublisher<SelectLevelFrameMessage> publisher;

        [Inject] private ILevelFrameFactory levelFrameFactory;
        
        private List<GameObject> levelFrames;
        private List<LevelData> levels;

        public override void Initialize()
        {
            base.Initialize();
            
            levels = staticDataProvider.Levels;
            levelFrames = new List<GameObject>(levels.Count);

            FillFrames().Forget();
        }

        // private async UniTaskVoid FillFrames()
        // {
        //     foreach (var levelData in levels)
        //     {
        //         var levelFrame = await levelFrameFactory.Create(holder, levelData.LevelIndex);
        //         levelFrame.AddListener(() =>
        //         {
        //             publisher.Publish(new SelectLevelFrameMessage(levelData));
        //             Close();
        //         });
        //         
        //         levelFrames.Add(levelFrame.gameObject);
        //     }
        // }
        
        private async UniTaskVoid FillFrames()
        {
            foreach (var levelData in levels)
            {
                var levelFrame = await levelFrameFactory.Create(holder, levelData.LevelIndex);
                levelFrame.AddListener(() =>
                {
                    publisher.Publish(new SelectLevelFrameMessage(levelData));
                    Close();
                });
                levelFrame.RectTransform.localScale = Vector3.one;
                levelFrames.Add(levelFrame.gameObject);
            }
        }        
        
        public override void OnDestroy()
        {
            base.OnDestroy();

            for (int i = levelFrames.Count - 1; i >= 0; i--)
            {
                if (!Addressables.ReleaseInstance(levelFrames[i].gameObject))
                {
                    GameObject.Destroy(levelFrames[i].gameObject);
                }
            }
        }
    }
}