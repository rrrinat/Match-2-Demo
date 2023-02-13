using System.Linq;
using Match2.Partial.Gameplay.Static;

namespace Match2.Partial.Gameplay.Level
{
    public class GoalsAchievedChecker
    {
        private LevelData currentLevelData;

        public GoalsAchievedChecker(LevelData currentLevelData)
        {
            this.currentLevelData = currentLevelData;
        }

        public bool IsGoalsAchieved()
        {
            var goals = currentLevelData.Goals;
            var allItemsDestroyed = goals.Values.All(i => i.Amount <= 0);

            return allItemsDestroyed;
        }
    }
}