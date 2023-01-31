using System.Text;
using Match2.Partial.Gameplay.Enums;
using UnityEngine;

namespace Match2.Partial.Gameplay.Static
{
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