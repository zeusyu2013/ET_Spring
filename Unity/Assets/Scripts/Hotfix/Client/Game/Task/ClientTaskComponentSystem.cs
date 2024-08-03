namespace ET.Client
{
    [EntitySystemOf(typeof(ClientTaskComponent))]
    public static partial class ClientTaskComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.ClientTaskComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ET.Client.ClientTaskComponent self)
        {
        }
    }
}