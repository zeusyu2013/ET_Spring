namespace ET.Server
{
    [EntitySystemOf(typeof(BuffCreateInfo))]
    [FriendOfAttribute(typeof(ET.Server.BuffCreateInfo))]
    public static partial class BuffCreateInfoSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.BuffCreateInfo self, int configId)
        {
            self.ConfigId = configId;
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.BuffCreateInfo self)
        {
            self.ConfigId = default;
        }
    }
}