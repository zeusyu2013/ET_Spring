using Unity.Mathematics;

namespace ET.Server
{
    [FriendOfAttribute(typeof(ET.Server.Action))]
    [FriendOfAttribute(typeof(ET.Server.ReliveComponent))]
    public static class BattleHelper
    {
        /// <summary>
        /// 伤害计算
        /// </summary>
        /// <param name="attacker"></param>
        /// <param name="target"></param>
        /// <param name="action"></param>
        public static void CalcDamage(Unit attacker, Unit target, Action action)
        {
            DamageActionParams actionParams = (DamageActionParams)action.Config.ActionParams;
            if (actionParams == null)
            {
                return;
            }

            // todo 伤害公式

            long damage = actionParams.AdditionalDamage;
            if (damage < 1)
            {
                Log.Error($"附加伤害配置错误，action:{action.ConfigId}");
                return;
            }

            // 伤害可以溢出，直接广播
            M2C_BattleResult m2CBattleResult = M2C_BattleResult.Create();
            m2CBattleResult.AttackerId = attacker.Id;
            m2CBattleResult.TargetId = target.Id;
            m2CBattleResult.Damage = damage;
            BattleMessageHelper.SendClient(target, m2CBattleResult, MessageNotifyType.MessageNotifyType_Broadcast);

            // todo:打断被攻击者的施法，或推迟读条时间等
            target.GetComponent<SkillStatusComponent>()?.BreakCasting();

            NumericComponent numericComponent = target.GetComponent<NumericComponent>();
            long hp = numericComponent[GamePropertyType.GamePropertyType_Hp];
            long result = 0;
            if (hp > damage)
            {
                result = hp - damage;
            }
            else
            {
                result = 0;
            }

            numericComponent[GamePropertyType.GamePropertyType_Hp] = result;

            if (result < 1)
            {
                Kill(attacker, target);
            }
        }

        private static void Kill(Unit killer, Unit target)
        {
            // todo 处理击杀事件等
            
            OnDead(target);
        }

        public static void OnDead(Unit deader)
        {
            ReliveComponent reliveComponent = deader.GetComponent<ReliveComponent>();
            if (reliveComponent == null)
            {
                return;
            }

            if (!deader.IsAlive())
            {
                return;
            }

            deader.Stop(0);

            reliveComponent.Alive = false;

            switch (deader.Type())
            {
                case UnitType.UnitType_Player:
                    // todo:死亡后处理
                    break;

                case UnitType.UnitType_Monster:
                {
                    long time = TimeInfo.Instance.ServerNow() + 3000;
                    deader.Scene().GetComponent<TimerComponent>().NewOnceTimer(time, TimerInvokeType.MonsterDeadTimer, deader);
                }
                    break;
            }
        }

        public static int CanCast(Unit unit, int castConfigId)
        {
            CastConfig config = CastConfigCategory.Instance.Get(castConfigId);
            if (config == null)
            {
                return ErrorCode.ERR_CastIsNull;
            }

            if (!unit.IsAlive())
            {
                return ErrorCode.ERR_AlreadyDead;
            }

            int err = unit.GetComponent<SkillStatusComponent>().CanCast(castConfigId);

            return err;
        }
    }
}