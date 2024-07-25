namespace ET.Server
{
    [EntitySystemOf(typeof(GameBuffContinueDamageComponent))]
    public static partial class GameBuffContinueDamageComponentSystem
    {
        [EntitySystem]
        private static void Awake(this GameBuffContinueDamageComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this GameBuffContinueDamageComponent self)
        {
        }

        [EntitySystem]
        private static void Update(this GameBuffContinueDamageComponent self)
        {
        }
    }
}