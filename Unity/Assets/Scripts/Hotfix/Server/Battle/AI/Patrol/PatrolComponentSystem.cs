namespace ET.Server
{
    [EntitySystemOf(typeof(PatrolComponent))]
    public static partial class PatrolComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.PatrolComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.PatrolComponent self)
        {
        }
    }
}