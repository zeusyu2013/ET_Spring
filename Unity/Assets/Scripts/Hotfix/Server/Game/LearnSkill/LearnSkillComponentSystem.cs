namespace ET.Server
{
    [EntitySystemOf(typeof(LearnSkillComponent))]
    [FriendOfAttribute(typeof(ET.Server.LearnSkillComponent))]
    public static partial class LearnSkillComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.LearnSkillComponent self)
        {
        }

        public static void LearnSkill(this LearnSkillComponent self, int skillConfig, int skillLevel)
        {
            if (self.LearnedSkills.Contains(skillConfig))
            {
                return;
            }

            // 扣除消耗
            SkillConfig config = SkillConfigCategory.Instance.Get(skillConfig, skillLevel);
            if (config == null)
            {
                return;
            }

            int ret = self.GetParent<Unit>().
                    GetComponent<CurrencyComponent>().
                    Dec(config.LearnCurrencyType, config.LearnCurrencyValue, "学习技能");
            if (ret != ErrorCode.ERR_Success)
            {
                return;
            }

            self.LearnedSkills.Add(skillConfig);
        }
    }
}