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
        private static void Destroy(this BagComponent self)
        {
            self.Capacity = 0;
            self.MaxCapacity = 0;
            self.GameItems.Clear();
        }

        [EntitySystem]
        private static void Deserialize(this BagComponent self)
        {
            foreach (var child in self.Children.Values)
            {
                self.GameItems.Add(child as GameItem);
            }
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

                EventSystem.Instance.Publish(self.Root(),
                    new BagOnAdd() { Unit = self.GetParent<Unit>(), GameItem = item, OldAmount = 0, NewAmount = amount });

                return true;
            }

            if (item.Config.MaxCount == 1)
            {
                item = self.AddChild<GameItem, int>(itemId);
                item.ConfigId = itemId;
                item.Amount = amount;
                self.GameItems.Add(item);

                EventSystem.Instance.Publish(self.Root(),
                    new BagOnAdd() { Unit = self.GetParent<Unit>(), GameItem = item, OldAmount = 0, NewAmount = 1 });

                return true;
            }

            long oldAmount = item.Amount;
            item.Amount = oldAmount + amount;

            EventSystem.Instance.Publish(self.Root(),
                new BagOnAdd() { Unit = self.GetParent<Unit>(), GameItem = item, OldAmount = oldAmount, NewAmount = oldAmount + amount });

            return true;
        }

        public static bool RemoveItem(this BagComponent self, int itemId, long itemAmount)
        {
            GameItem item = self.GetGameItemByConfig(itemId);
            if (item == null)
            {
                return false;
            }

            if (item.Amount < itemAmount)
            {
                return false;
            }

            long oldAmount = item.Amount;
            item.Amount = oldAmount - itemAmount;

            if (item.Amount == 0)
            {
                self.GameItems.Remove(item);
                item.Dispose();
            }

            EventSystem.Instance.Publish(self.Root(),
                new BagOnRemove() { GameItemConfig = itemId, OldAmount = oldAmount, NewAmount = oldAmount - itemAmount });

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