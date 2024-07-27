namespace ET.Server
{
    [EntitySystemOf(typeof(Cast))]
    public static partial class CastSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.Cast self, int args2)
        {
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.Cast self)
        {
        }
    }
}