namespace ET
{
    [EntitySystemOf(typeof(GameBuffActionComponent))]
    public static partial class GameBuffActionComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.GameBuffActionComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ET.GameBuffActionComponent self)
        {
        }
    }
}