namespace ET.Server
{
    [EntitySystemOf(typeof(Action))]
    [FriendOfAttribute(typeof(ET.Server.Action))]
    public static partial class ActionSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.Action self, int configId)
        {
            self.ConfigId = configId;
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.Action self)
        {
            self.ConfigId = default;
            self.Caster = default;
            self.Owner = default;
        }
    }
}