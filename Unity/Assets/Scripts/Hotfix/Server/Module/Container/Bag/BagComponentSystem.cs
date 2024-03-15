namespace ET.Server
{
    [EntitySystemOf(typeof(BagComponent))]
    [FriendOf(typeof(BagComponent))]
    public static partial class BagComponentSystem
    {
        [EntitySystem]
        private static void Awake(this BagComponent self)
        {
            self.PlayerId = self.GetParent<Unit>().Id;
            self.Capacity = GlobalDataConfigCategory.Instance.BagCapacity;
            self.MaxCapacity = GlobalDataConfigCategory.Instance.BagMaxCapacity;
            self.ItemInfos = new();
        }

        public static async ETTask<bool> AddItem(this BagComponent self, int itemId, long itemCount)
        {
            ItemInfo item = self.ItemInfos.Find(x => x.ItemId == itemId);
            if (item == null)
            {
                item = ItemInfo.Create();
                item.ItemId = itemId;
                item.ItemCount = 0;
                self.ItemInfos.Add(item);
            }

            using (await self.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.Bag, self.PlayerId))
            {
                item.ItemCount += itemCount;

                await self.Root().GetComponent<DBManagerComponent>().GetZoneDB(self.Zone()).Save(self);
            }

            return true;
        }

        public static async ETTask<bool> RemoveItem(this BagComponent self, int itemId, long itemCount)
        {
            ItemInfo item = self.ItemInfos.Find(x => x.ItemId == itemId);
            if (item == null)
            {
                return false;
            }

            if (item.ItemCount < itemCount)
            {
                return false;
            }

            using (await self.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.Bag, self.PlayerId))
            {
                item.ItemCount -= itemCount;
                await self.Root().GetComponent<DBManagerComponent>().GetZoneDB(self.Zone()).Save(self);
            }

            return true;
        }
    }
}