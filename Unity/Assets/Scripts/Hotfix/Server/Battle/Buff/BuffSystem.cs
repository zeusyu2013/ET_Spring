namespace ET.Server
{
    [EntitySystemOf(typeof(Buff))]
    public static partial class BuffSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.Buff self, int args2)
        {
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.Buff self)
        {
        }
    }
}