namespace ET.Server
{
    [EntitySystemOf(typeof(QueueComponent))]
    public static partial class QueueComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.QueueComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.QueueComponent self)
        {
        }
    }
}