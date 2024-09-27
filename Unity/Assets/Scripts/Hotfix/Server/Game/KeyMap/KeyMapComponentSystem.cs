namespace ET.Server
{
    [EntitySystemOf(typeof(KeyMapComponent))]
    public static partial class KeyMapComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.KeyMapComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.KeyMapComponent self)
        {
        }
    }
}