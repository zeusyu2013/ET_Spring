namespace ET.Server
{
    [EntitySystemOf(typeof(BulletComponent))]
    [FriendOfAttribute(typeof(ET.Server.BulletComponent))]
    public static partial class BulletComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.BulletComponent self, int configId)
        {
            self.ConfigId = configId;
            self.AddComponent<ActionTempComponent>();
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.BulletComponent self)
        {
        }

        public static Unit GetOwner(this BulletComponent self)
        {
            return self.Scene().GetComponent<UnitComponent>().Get(self.OwnerId);
        }
    }
}