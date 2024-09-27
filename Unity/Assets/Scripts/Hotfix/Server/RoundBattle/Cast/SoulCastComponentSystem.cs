namespace ET.Server
{
    [EntitySystemOf(typeof(SoulCastComponent))]
    public static partial class SoulCastComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.SoulCastComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.SoulCastComponent self)
        {
        }

        public static SoulCast Create(this ET.Server.SoulCastComponent self, int configId)
        {
            return self.AddChild<SoulCast, int>(configId);
        }
    }
}