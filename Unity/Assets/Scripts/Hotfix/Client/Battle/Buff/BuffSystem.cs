using ET.Client;

namespace ET
{
    [EntitySystemOf(typeof(ClientBuff))]
    [FriendOfAttribute(typeof(ET.Client.ClientBuff))]
    public static partial class BuffSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.ClientBuff self, int configId)
        {
            self.ConfigId = configId;
        }

        [EntitySystem]
        private static void Destroy(this ET.Client.ClientBuff self)
        {
            self.ConfigId = default;
            self.Owner = default;
            self.CreateTime = default;
            self.ExpiredTime = default;
        }
    }
}