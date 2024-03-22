namespace ET
{
    [EntitySystemOf(typeof(GameBuffControlComponent))]
    public static partial class GameBuffControlComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.GameBuffControlComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ET.GameBuffControlComponent self)
        {
        }
    }
}