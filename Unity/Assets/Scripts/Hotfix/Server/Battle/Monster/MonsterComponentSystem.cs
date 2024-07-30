namespace ET.Server
{
    [EntitySystemOf(typeof(MonsterComponent))]
    [FriendOfAttribute(typeof(ET.Server.MonsterComponent))]
    public static partial class MonsterComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.MonsterComponent self, int configId)
        {
            self.ConfigId = configId;
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.MonsterComponent self)
        {
            self.Scene().GetComponent<MonsterMapComponent>().OnMonsterDead(self.ConfigId);
        }
    }
}