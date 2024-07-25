namespace ET.Server
{
    [EntitySystemOf(typeof(GameBuffActionComponent))]
    public static partial class GameBuffActionComponentSystem
    {
        [EntitySystem]
        private static void Awake(this GameBuffActionComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this GameBuffActionComponent self)
        {
        }
    }
}