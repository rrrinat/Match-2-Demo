using Match2.Partial.Gameplay.Static;

namespace Match2.Partial.Messages
{
    public struct OnItemDestroyMessage
    {
        public ItemData ItemData;

        public OnItemDestroyMessage(ItemData itemData)
        {
            this.ItemData = itemData;
        }
    }
}