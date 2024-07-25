namespace ET.Server
{
    [EntitySystemOf(typeof(GameBuffControlComponent))]
    public static partial class GameBuffControlComponentSystem
    {
        [EntitySystem]
        private static void Awake(this GameBuffControlComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this GameBuffControlComponent self)
        {
        }
    }
}