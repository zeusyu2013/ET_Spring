using System.Collections.Generic;

namespace ET.Server
{
    [EntitySystemOf(typeof(BagComponent))]
    [FriendOf(typeof(BagComponent))]
    [FriendOf(typeof(GameItem))]
    public static partial class BagComponentSystem
    {
        [EntitySystem]
        private static void Awake(this BagComponent self)
        {
            self.Capacity = GlobalDataConfigCategory.Instance.BagCapacity;
            self.MaxCapacity = GlobalDataConfigCategory.Instance.BagMaxCapacity;
        }

        [EntitySystem]
        private static void Deserialize(this BagComponent self)
        {
            foreach (var child in self.Children.Values)
            {
                self.AddItem(child as GameItem);
            }
        }

        [EntitySystem]
        private static void GetComponentSys(this BagComponent self, System.Type type)
        {
            self.Root().GetComponent<DBCacheComponent>().Save(self).Coroutine();
        }

        public static bool AddItem(this BagComponent self, GameItem item)
        {
            if (item == null || item.IsDisposed)
            {
                return false;
            }

            self.AddChild(item);
            self.GameItems.Add(item);

            return true;
        }

        public static bool AddItem(this BagComponent self, int itemId, long amount)
        {
            if (amount < 1)
            {
                return false;
            }

            GameItem item = self.GetGameItemByConfig(itemId);
            if (item == null)
            {
                item = self.AddChild<GameItem, int>(itemId);
                item.ConfigId = itemId;
                item.Amount = amount;
                self.GameItems.Add(item);

                EventSystem.Instance.Publish(self.Scene(), new BagOnAdd() { GameItem = item });

                return true;
            }

            item.Amount += amount;

            return true;
        }

        public static bool RemoveItem(this BagComponent self, int itemId, long itemCount)
        {
            GameItem item = self.GetGameItemByConfig(itemId);
            if (item == null)
            {
                return false;
            }

            if (item.Amount < itemCount)
            {
                return false;
            }

            item.Amount -= itemCount;

            if (item.Amount == 0)
            {
                self.GameItems.Remove(item);
                item.Dispose();
            }

            return true;
        }

        public static GameItem GetGameItemByConfig(this BagComponent self, int config)
        {
            GameItem item = null;

            foreach (var refItem in self.GameItems)
            {
                item = refItem;
                if (item == null)
                {
                    continue;
                }

                if (item.ConfigId == config)
                {
                    break;
                }
            }

            return item;
        }

        public static List<EntityRef<GameItem>> GetGameItems(this BagComponent self)
        {
            return self.GameItems;
        }
    }
}