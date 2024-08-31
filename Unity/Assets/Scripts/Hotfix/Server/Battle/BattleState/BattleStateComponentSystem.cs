namespace ET.Server
{
    [EntitySystemOf(typeof(BattleStateComponent))]
    public static partial class BattleStateComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.BattleStateComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.BattleStateComponent self)
        {
        }

        public static void Enter(this BattleStateComponent self)
        {
        }

        public static void Exit(this BattleStateComponent self)
        {
        }
    }
}