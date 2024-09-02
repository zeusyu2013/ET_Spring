namespace ET.Server
{
    [EntitySystemOf(typeof(SoulRune))]
    [FriendOfAttribute(typeof(ET.Server.SoulRune))]
    public static partial class SoulRuneSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.SoulRune self, int configId)
        {
            self.ConfigId = configId;
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.SoulRune self)
        {
        }
    }
}