namespace ET.Client
{
    [EntitySystemOf(typeof(ClientCast))]
    [FriendOfAttribute(typeof(ET.Client.ClientCast))]
    public static partial class CastSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.ClientCast self, int configId)
        {
            self.ConfigId = configId;
        }

        [EntitySystem]
        private static void Destroy(this ET.Client.ClientCast self)
        {
            self.ConfigId = default;
            self.CasterId = default;
            self.Targets.Clear();
        }
    }
}