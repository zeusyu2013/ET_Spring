using ET.Client;

namespace ET
{
    [EntitySystemOf(typeof(BagComponent))]
    [FriendOfAttribute(typeof(ET.GameItem))]
    [FriendOfAttribute(typeof(ET.BagComponent))]
    public static partial class BagComponentSystem
    {
        public static void UseGameItem(this BagComponent self, int itemConfig, long useCount)
        {
            long count = self.GetItemCount(itemConfig);
            if (useCount > count)
            {
                return;
            }

            bool removeResult = self.RemoveItem(itemConfig, useCount);
            if (!removeResult)
            {
                return;
            }

            EventSystem.Instance.Publish(self.Scene(), new OnItemUsed() { });
        }

        public static bool AddItem(this BagComponent self, int itemConfig, long itemCount)
        {
            long count = self.GetItemCount(itemConfig);
            if (count == 0)
            {
                GameItem item = self.AddChild<GameItem, int>(itemConfig);
                item.ItemCount = itemCount;
                self.GameItems.Add(item);
            }

            foreach (var refItem in self.GameItems)
            {
                GameItem item = refItem;
                if (item == null)
                {
                    continue;
                }

                if (item.ItemConfig == itemConfig)
                {
                    item.ItemCount += itemCount;
                    break;
                }
            }

            return true;
        }

        public static bool RemoveItem(this BagComponent self, int itemConfig, long itemCount)
        {
            long count = self.GetItemCount(itemConfig);
            if (count < itemCount)
            {
                return false;
            }

            foreach (var refItem in self.GameItems)
            {
                GameItem item = refItem;
                if (item == null)
                {
                    continue;
                }

                if (item.ItemConfig == itemConfig)
                {
                    item.ItemCount -= itemCount;
                    break;
                }
            }

            return true;
        }

        public static long GetItemCount(this BagComponent self, int itemConfig)
        {
            long count = 0;
            foreach (var refItem in self.GameItems)
            {
                GameItem item = refItem;
                if (item.ItemConfig == itemConfig)
                {
                    count += item.ItemCount;
                }
            }

            return count;
        }
    }
}