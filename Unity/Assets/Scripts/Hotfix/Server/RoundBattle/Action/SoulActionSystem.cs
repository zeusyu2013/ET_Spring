namespace ET.Server
{
    [EntitySystemOf(typeof(SoulAction))]
    [FriendOfAttribute(typeof(ET.Server.SoulAction))]
    public static partial class SoulActionSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.SoulAction self, int configId)
        {
            self.ConfigId = configId;
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.SoulAction self)
        {
            self.ConfigId = default;
            self.Caster = default;
            self.Owner = default;
        }
    }
}