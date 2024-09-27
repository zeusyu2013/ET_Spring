namespace ET.Server
{
    [SoulAction(SoulActionType.SoulActionType_Damage)]
    [FriendOfAttribute(typeof(ET.Server.SoulCast))]
    public class Damage_SoulActionHandler : ISoulAction
    {
        public void Run(SoulAction soulAction, SoulActionTriggerType type)
        {
            SoulCast cast = soulAction.Cast;
            if (cast == null || type != SoulActionTriggerType.CastHit)
            {
                return;
            }

            if (cast.Targets.Count < 1)
            {
                return;
            }

            foreach (EntityRef<Soul> soul in cast.Targets)
            {
                Soul target = soul;
                if (target == null || target.IsDisposed)
                {
                    continue;
                }

                BattleHelper.CalcDamage(cast.Caster, target, soulAction);
            }
        }
    }
}