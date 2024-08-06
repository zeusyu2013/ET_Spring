namespace ET.Server
{
    [EntitySystemOf(typeof(SkillStatusComponent))]
    [FriendOfAttribute(typeof(ET.Server.SkillStatusComponent))]
    [FriendOfAttribute(typeof(ET.Server.Cast))]
    public static partial class SkillStatusComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.SkillStatusComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.SkillStatusComponent self)
        {
            self.CurrentSkillCastInstanceId = default;
            self.CurrentSkillCastId = default;
            self.CurrentSkillStartTime = default;
            self.CurrentSkillStatusType = SkillStatusType.Uninitialize;
        }

        public static int CanCast(this SkillStatusComponent self, int castConfigId)
        {
            Unit unit = self.GetParent<Unit>();
            if (unit == null)
            {
                return ErrorCode.ERR_CasterIsNull;
            }

            NumericComponent numericComponent = unit.GetComponent<NumericComponent>();
            if (numericComponent == null)
            {
                return ErrorCode.ERR_NotFoundComponent;
            }

            if (numericComponent[GamePropertyType.GP_Silent] > 0)
            {
                return ErrorCode.ERR_Silent;
            }

            if (self.Cooldowns.TryGetValue(castConfigId, out long cd))
            {
                if (TimeInfo.Instance.ServerNow() <= cd)
                {
                    return ErrorCode.ERR_CastCDing;
                }
            }

            return ErrorCode.ERR_Success;
        }

        public static bool StartCast(this SkillStatusComponent self, Cast cast)
        {
            int castConfigId = cast.ConfigId;
            if (self.CanCast(castConfigId) != ErrorCode.ERR_Success)
            {
                return false;
            }

            if (cast.Config.Casting)
            {
                return true;
            }

            long now = TimeInfo.Instance.ServerNow();

            self.CurrentSkillCastId = cast.Id;
            self.CurrentSkillCastInstanceId = cast.InstanceId;
            self.CurrentSkillStartTime = now;
            self.CurrentSkillStatusType = SkillStatusType.Initialized;

            int cooldown = cast.Config.CastCooldown;
            if (cooldown > 0)
            {
                self.Cooldowns[castConfigId] = now + cooldown;

                Unit unit = self.GetParent<Unit>();
                M2C_CooldownChange m2CCooldownChange = M2C_CooldownChange.Create();
                m2CCooldownChange.CastConfigId.Add(castConfigId);
                m2CCooldownChange.CooldownCD.Add(self.Cooldowns[castConfigId]);
                m2CCooldownChange.CooldownStartTime.Add(now);
                BattleMessageHelper.SendClient(unit, m2CCooldownChange, MessageNotifyType.MessageNotifyType_Self);
            }

            return true;
        }

        public static bool Casting(this SkillStatusComponent self, Cast cast)
        {
            if (cast.Config.Casting)
            {
                return true;
            }

            if (self.CurrentSkillStatusType != SkillStatusType.Initialized || self.CurrentSkillCastInstanceId != cast.InstanceId)
            {
                return false;
            }

            self.CurrentSkillStatusType = SkillStatusType.Running;

            return true;
        }

        public static bool Finish(this SkillStatusComponent self, Cast cast)
        {
            if (cast.Config.Casting)
            {
                return true;
            }

            if (self.CurrentSkillStatusType != SkillStatusType.Running || self.CurrentSkillCastInstanceId != cast.InstanceId)
            {
                return false;
            }

            self.CurrentSkillStatusType = SkillStatusType.Finish;

            return true;
        }

        public static bool BreakCasting(this SkillStatusComponent self)
        {
            self.ClearInfo();

            return true;
        }

        private static void ClearInfo(this SkillStatusComponent self)
        {
            self.CurrentSkillCastId = default;
            self.CurrentSkillCastInstanceId = default;
            self.CurrentSkillStartTime = default;
            self.CurrentSkillStatusType = SkillStatusType.Uninitialize;
        }
    }
}