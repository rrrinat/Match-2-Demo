using System;
using System.Text;
using Match2.Partial.Gameplay.Enums;

namespace Match2.Partial.Gameplay.Static
{
    [Serializable]
    public struct ItemData
    {
        public ItemType Type;
        public ItemColor Color;

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("ItemType ")
                .Append(Type.ToString())
                .Append(" ")
                .Append("ItemColor ")
                .Append(Color.ToString());

            var message = stringBuilder.ToString();
            stringBuilder.Clear();

            return message;
        }
    }
}