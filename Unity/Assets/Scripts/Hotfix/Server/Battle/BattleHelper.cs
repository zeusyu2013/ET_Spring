using System.Collections.Generic;
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
            M2C_DamageResult m2CBattleResult = M2C_DamageResult.Create();
            m2CBattleResult.AttackerId = attacker.Id;
            m2CBattleResult.TargetId = target.Id;
            m2CBattleResult.Damage = damage;
            BattleMessageHelper.SendClient(target, m2CBattleResult, MessageNotifyType.MessageNotifyType_Broadcast);

            // todo:打断被攻击者的施法，或推迟读条时间等
            target.GetComponent<SkillStatusComponent>()?.BreakCasting();

            NumericComponent numericComponent = target.GetComponent<NumericComponent>();
            long hp = numericComponent[GamePropertyType.GP_Hp];
            long result = 0;
            if (hp > damage)
            {
                result = hp - damage;
            }
            else
            {
                result = 0;
            }

            numericComponent[GamePropertyType.GP_Hp] = result;

            if (result < 1)
            {
                Kill(attacker, target);
            }
        }

        public static void CalcTreatment(Unit caster, Unit target, Action action)
        {
            TreatmentParams treatmentParams = (TreatmentParams)action.Config.ActionParams;
            if (treatmentParams == null)
            {
                Log.Error($"治疗行为配置错误，行为编号：{action.ConfigId}");
                return;
            }

            long treatment = treatmentParams.TreatValue;
            if (treatment < 1)
            {
                Log.Error($"治疗行为配置错误，恢复生命值为0，行为编号：{action.ConfigId}");
                return;
            }

            // 治疗可以溢出，直接广播
            M2C_TreatResult m2CTreatResult = M2C_TreatResult.Create();
            m2CTreatResult.CasterId = caster.Id;
            m2CTreatResult.TargetId = target.Id;
            m2CTreatResult.TreatValue = treatment;
            BattleMessageHelper.SendClient(target, m2CTreatResult, MessageNotifyType.MessageNotifyType_Broadcast);

            NumericComponent numericComponent = target.GetComponent<NumericComponent>();
            long hp = numericComponent[GamePropertyType.GP_Hp];
            long maxHp = numericComponent[GamePropertyType.GP_MaxHp];
            long result = hp + treatment;
            if (result > maxHp)
            {
                numericComponent[GamePropertyType.GP_Hp] = maxHp;
            }
            else
            {
                numericComponent[GamePropertyType.GP_Hp] = result;
            }
        }

        public static void Relive(Unit caster, Unit target, Action action)
        {
            ReliveParams reliveParams = (ReliveParams)action.Config.ActionParams;
            if (reliveParams == null)
            {
                Log.Error($"复活类行为配置错误，行为编号：{action.ConfigId}");
                return;
            }

            long hp = reliveParams.Hp;
            long mp = reliveParams.Mp;
            if (hp < 1)
            {
                Log.Error($"复活类行为配置错误，复活后生命值为0，行为编号：{action.ConfigId}");
                return;
            }

            int err = target.SetRelive(hp, mp);
            if (err != ErrorCode.ERR_Success)
            {
                Log.Error($"复活行为失败，错误信息：{err}");
            }
        }

        private static void Kill(Unit killer, Unit target)
        {
            // todo 处理击杀事件等

            OnDead(killer, target);
        }

        private static void OnDead(Unit killer, Unit deader)
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

                    if (killer.Type() == UnitType.UnitType_Player)
                    {
                        MonsterConfig config = MonsterConfigCategory.Instance.Get(deader.ConfigId);
                        List<DropItem> items = new();
                        deader.Scene().GetComponent<DropComponent>().Drop(config.DropConfig, ref items);
                        if (items.Count > 0)
                        {
                            foreach (DropItem item in items)
                            {
                                killer.GetComponent<BagComponent>().AddItem(item.ItemConfig, item.ItemAmount);
                            }
                        }
                    }
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