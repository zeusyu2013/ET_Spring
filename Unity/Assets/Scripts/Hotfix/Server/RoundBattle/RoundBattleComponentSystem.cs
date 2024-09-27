using System.Collections.Generic;

namespace ET.Server
{
    [EntitySystemOf(typeof(RoundBattleComponent))]
    [FriendOfAttribute(typeof(ET.Server.RoundBattleComponent))]
    public static partial class RoundBattleComponentSystem
    {
        [Invoke(TimerInvokeType.BattleSpeedTimer)]
        public class BattleSpeedTimer : ATimer<RoundBattleComponent>
        {
            protected override void Run(RoundBattleComponent self)
            {
                self.UpdateSpeed();
            }
        }

        [EntitySystem]
        private static void Awake(this ET.Server.RoundBattleComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.RoundBattleComponent self)
        {
        }

        public static void Start(this ET.Server.RoundBattleComponent self)
        {
            // 创建敌方单位
            BattlePVEConfig config = BattlePVEConfigCategory.Instance.Get(self.PVEConfig);
            if (config == null)
            {
                Log.Error($"创建敌方单位失败，{self.PVEConfig}");
                return;
            }

            foreach ((int configId, BattlePosition position) in config.Monsters)
            {
                UnitFactory.CreateRoundBattleUnit(self.Scene(), configId, (int)position);
            }

            Unit unit = self.Owner;
            Dictionary<int, int> battle = unit.GetComponent<SoulComponent>().GetBattle();

            // 创建我方单位
            foreach ((int configId, int position) in battle)
            {
                UnitFactory.CreateRoundBattleUnit(self.Scene(), configId, position);
            }

            self.Scene().GetComponent<TimerComponent>().NewRepeatedTimer(1000, TimerInvokeType.BattleSpeedTimer, self);
        }

        private static void UpdateSpeed(this RoundBattleComponent self)
        {
        }
    }
}