namespace ET.Server
{
    [EntitySystemOf(typeof(BuffComponent))]
    public static partial class BuffComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.BuffComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.BuffComponent self)
        {
        }
    }
}