namespace ET.Server
{
    [EntitySystemOf(typeof(CastComponent))]
    public static partial class CastComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.CastComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.CastComponent self)
        {
        }

        public static Cast Create(this CastComponent self, int configId)
        {
            return self.AddChild<Cast, int>(configId);
        }

        [EntitySystem]
        private static void Deserialize(this ET.Server.CastComponent self)
        {
        }
    }
}