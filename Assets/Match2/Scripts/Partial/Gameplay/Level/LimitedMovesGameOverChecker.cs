using Match2.Partial.Gameplay.Static;

namespace Match2.Partial.Gameplay.Level
{
    public class LimitedMovesGameOverChecker
    {
        private LevelData currentLevelData;

        public LimitedMovesGameOverChecker(LevelData currentLevelData)
        {
            this.currentLevelData = currentLevelData;
        }

        public bool IsMovesOver()
        {
            return currentLevelData.MovesCount <= 0;
        }
    }
}