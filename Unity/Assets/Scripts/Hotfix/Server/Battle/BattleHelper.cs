using Unity.Mathematics;

namespace ET.Server
{
    [FriendOfAttribute(typeof(ET.Server.Action))]
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
        }
    }
}