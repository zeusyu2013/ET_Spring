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
    }
}