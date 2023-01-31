using System.Text;

namespace Match2.Partial.Gameplay.Static
{
    public struct GoalData 
    {
        public ItemData ItemData;
        public int Amount;

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("ItemData ")
                .Append(ItemData.ToString())
                .Append(" ")
                .Append("Amount ")
                .Append(Amount.ToString());

            var message = stringBuilder.ToString();
            stringBuilder.Clear();

            return message;
        }
    }
}
