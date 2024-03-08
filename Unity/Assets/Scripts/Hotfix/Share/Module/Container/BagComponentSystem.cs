using System.Collections.Generic;
using System.Linq;
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

        /// <summary>
        /// 添加单个道具
        /// </summary>
        /// <param name="self"></param>
        /// <param name="itemConfig"></param>
        /// <param name="itemCount"></param>
        /// <returns></returns>
        public static bool AddItem(this BagComponent self, int itemConfig, long itemCount)
        {
            if (itemCount < 1)
            {
                return false;
            }
            
            long count = self.GetItemCount(itemConfig);
            if (count < 1)
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

        /// <summary>
        /// 批量添加多个道具，会自动合并
        /// </summary>
        /// <param name="self"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public static bool AddItems(this BagComponent self, Dictionary<int, long> items)
        {
            Dictionary<int, long> onlyItems = new();
            foreach (var kv in items)
            {
                if (onlyItems.ContainsKey(kv.Key))
                {
                    onlyItems[kv.Key] += kv.Value;
                }
                else
                {
                    onlyItems.Add(kv.Key, kv.Value);
                }
            }
            
            foreach (var kv in onlyItems)
            {
                self.AddItem(kv.Key, kv.Value);
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

                if (item.ItemConfig != itemConfig)
                {
                    continue;
                }
                
                item.ItemCount -= itemCount;

                if (item.ItemCount == 0)
                {
                    self.GameItems.Remove(item);
                    item.Dispose();
                }
                
                break;
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