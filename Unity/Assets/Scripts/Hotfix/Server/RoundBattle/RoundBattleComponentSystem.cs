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
                self.BattleSpeedProgress();
            }
        }

        [EntitySystem]
        private static void Awake(this ET.Server.RoundBattleComponent self, int configId)
        {
            self.ConfigId = configId;
            self.Pause = false;
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.RoundBattleComponent self)
        {
            self.ConfigId = default;
            self.Owner = default;
            self.Pause = default;

            self.Units.Clear();
        }

        public static void Start(this ET.Server.RoundBattleComponent self)
        {
            // 创建敌方单位
            BattlePVEConfig config = BattlePVEConfigCategory.Instance.Get(self.ConfigId);
            if (config == null)
            {
                Log.Error($"创建敌方单位失败，{self.ConfigId}");
                return;
            }

            foreach ((int configId, BattlePosition position) in config.Monsters)
            {
                Unit battleUnit = UnitFactory.CreateRoundBattleUnit(self.Scene(), configId, (int)position);
                self.Units.Add(battleUnit);
            }

            Unit unit = self.Owner;
            Dictionary<int, int> battle = unit.GetComponent<SoulComponent>().GetBattle();

            // 创建我方单位
            foreach ((int configId, int position) in battle)
            {
                Unit battleUnit = UnitFactory.CreateRoundBattleUnit(self.Scene(), configId, position);
                self.Units.Add(battleUnit);
            }

            self.Scene().GetComponent<TimerComponent>().NewFrameTimer(TimerInvokeType.BattleSpeedTimer, self);
        }

        public static void Pause(this RoundBattleComponent self, bool pause)
        {
            self.Pause = pause;
        }

        private static void BattleSpeedProgress(this ET.Server.RoundBattleComponent self)
        {
            if (self.Pause)
            {
                return;
            }
            
            long now = TimeInfo.Instance.ServerNow();

            foreach (EntityRef<Unit> entityRef in self.Units)
            {
                Unit unit = entityRef;
                if (!unit.IsAlive())
                {
                    continue;
                }

                unit.GetComponent<BattleProgressComponent>().Progress();
            }
        }
    }
}