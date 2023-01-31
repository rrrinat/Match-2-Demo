using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Match2.Common.UI.Windows;
using Match2.Partial.Gameplay.GameStates;
using Match2.Partial.Gameplay.GameStates.States;
using Match2.Partial.Gameplay.Static;
using Match2.Partial.Messages;
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
        
        private List<GameObject> levelFrames;
        private List<LevelData> levels;

        public void Initialize()
        {
            levels = staticDataProvider.Levels;
            levelFrames = new List<GameObject>(levels.Count);

            FillFrames().Forget();
        }

        private async UniTaskVoid FillFrames()
        {
            foreach (var levelData in levels)
            {
                var instance = await Addressables.InstantiateAsync("SelectLevelFrame");
                var levelFrame = instance.GetComponent<SelectLevelFrame>();
                levelFrame.Initialize();
                levelFrame.RectTransform.SetParent(holder);
                levelFrame.SetLabel(levelData.LevelIndex.ToString());

                levelFrame.AddListener(() =>
                {
                    publisher.Publish(new SelectLevelFrameMessage(levelData));
                    Close();
                });
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