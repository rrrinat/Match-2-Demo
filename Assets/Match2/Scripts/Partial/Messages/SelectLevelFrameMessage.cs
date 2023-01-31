using Match2.Partial.Gameplay.Static;

namespace Match2.Partial.Messages
{
    public struct SelectLevelFrameMessage
    {
        public LevelData LevelData;

        public SelectLevelFrameMessage(LevelData levelData)
        {
            this.LevelData = levelData;
        }
    }
}