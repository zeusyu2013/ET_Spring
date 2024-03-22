namespace ET
{
    [EntitySystemOf(typeof(GameBuffContinueDamageComponent))]
    public static partial class GameBuffContinueDamageComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.GameBuffContinueDamageComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ET.GameBuffContinueDamageComponent self)
        {
        }
    }
}