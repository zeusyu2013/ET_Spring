using System.Collections.Generic;
using Unity.Mathematics;

namespace ET
{
    [EntitySystemOf(typeof(SkillComponent))]
    [FriendOfAttribute(typeof(ET.SkillComponent))]
    public static partial class SkillComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.SkillComponent self)
        {
            int configId = self.GetParent<Unit>().ConfigId;
            UnitConfig config = UnitConfigCategory.Instance.Get(configId);
            if (config == null)
            {
                Log.Error($"Unit Config没有找到: {configId}");
                return;
            }

            self.Skills = config.Skills;

            self.CreateSkillEntities();
        }

        [EntitySystem]
        private static void Destroy(this ET.SkillComponent self)
        {
            self.Skills.Clear();
        }

        private static void CreateSkillEntities(this SkillComponent self)
        {
            if (self.Skills.Count < 1)
            {
                return;
            }

            foreach (int skillConfig in self.Skills)
            {
                self.AddChild<Skill, int, int>(skillConfig, 1);
            }
        }

        public static int Cast(this SkillComponent self, int skillConfig, int level)
        {
            if (!self.Skills.Contains(skillConfig))
            {
                return SkillErrorCode.ERR_SkillConfigNotFound;
            }

            SkillConfig config = SkillConfigCategory.Instance.Get(skillConfig, level);
            if (config == null)
            {
                return SkillErrorCode.ERR_SkillConfigNotFound;
            }

            // 检查消耗
            Unit unit = self.GetParent<Unit>();
            long current = unit.GetLong(GamePropertyType.GamePropertyType_Mp);
            if (current < config.Consume)
            {
                return SkillErrorCode.ERR_SkillConsumeNotEnough;
            }

            // 扣除消耗
            unit.DecLong(GamePropertyType.GamePropertyType_Mp, config.Consume);

            // 处理技能流程
            int ret = self.Process(skillConfig, level);
            if (ret != SkillErrorCode.ERR_Success)
            {
                return ret;
            }

            return SkillErrorCode.ERR_Success;
        }

        private static int Process(this SkillComponent self, int skillConfig, int level)
        {
            List<Unit> units = new();
            self.GetParent<Unit>().GetComponent<SelectTargetComponent>().Check(skillConfig, level, ref units);
            if (units.Count < 1)
            {
                return SkillErrorCode.ERR_SkillNotTarget;
            }

            SkillConfig config = SkillConfigCategory.Instance.Get(skillConfig, level);

            foreach (Unit unit in units)
            {
                if (unit == null || unit.IsDisposed)
                {
                    continue;
                }

                long hp = unit.GetLong(GamePropertyType.GamePropertyType_Hp);
                long def = unit.GetLong(GamePropertyType.GamePropertyType_Def);

                long atk = self.GetParent<Unit>().GetLong(GamePropertyType.GamePropertyType_Atk);
                long damage = atk * config.Ratio / 100 + config.Base;

                hp = math.max(0, hp + def - damage);
                unit.SetLong(GamePropertyType.GamePropertyType_Hp, hp);

                if (hp < 1)
                {
                    // 通知死亡
                    EventSystem.Instance.Publish(self.Root(), new UnitDie() { Self = unit, Killer = self.GetParent<Unit>() });
                }
            }

            return SkillErrorCode.ERR_Success;
        }
    }
}