using System.Collections.Generic;

namespace ET.Server
{
    [EntitySystemOf(typeof(SoulCast))]
    [FriendOfAttribute(typeof(ET.Server.SoulCast))]
    public static partial class SoulCastSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.SoulCast self, int configId)
        {
            self.ConfigId = configId;
            self.AddComponent<SoulActionComponent>();
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.SoulCast self)
        {
            self.ConfigId = default;
            self.Caster = default;
            self.Targets.Clear();
        }

        public static int Cast(this SoulCast self)
        {
            int ret = self.CheckCast();
            if (ret != ErrorCode.ERR_Success)
            {
                return ret;
            }
            
            self.SelectTargets();

            ret = self.CheckBeforeCast();
            if (ret != ErrorCode.ERR_Success)
            {
                return ret;
            }
            
            self.CastAsync().Coroutine();

            return ErrorCode.ERR_Success;
        }

        private static int CheckCast(this SoulCast self)
        {
            if (self == null || self.IsDisposed)
            {
                return ErrorCode.ERR_SoulCastIsNull;
            }

            Soul caster = self.Caster;
            if (caster == null || caster.IsDisposed)
            {
                return ErrorCode.ERR_SoulCasterIsNull;
            }

            return ErrorCode.ERR_Success;
        }

        private static void SelectTargets(this SoulCast self)
        {
            
        }

        private static int CheckBeforeCast(this SoulCast self)
        {
            return ErrorCode.ERR_Success;
        }

        private static async ETTask CastAsync(this SoulCast self)
        {
            Soul soul = self.Caster;

            List<CastHitInfo> infos = self.Config.HitInfos;
            if (infos.Count < 1)
            {
                return;
            }

            foreach (CastHitInfo info in infos)
            {
                if (info.HitSelf)
                {
                    self.HandleHitSelf(info);
                }
                else
                {
                    self.HandleHitTarget(info);
                }
            }
            
            self.CastFinish();
            
            await ETTask.CompletedTask;
        }

        private static void HandleHitSelf(this SoulCast self, CastHitInfo info)
        {
            self.SelectTargets();
            if (self.Targets.Count < 1)
            {
                return;
            }

            Soul soul = self.Caster;

            if (info.HitAction > 0)
            {
                self.Create(info.HitAction, soul, SoulActionTriggerType.CastHit);
            }

            if (info.SelfBuff > 0)
            {
                soul.GetComponent<SoulBuffComponent>();
            }
        }

        private static void HandleHitTarget(this SoulCast self, CastHitInfo info)
        {
            self.SelectTargets();
            if (self.Targets.Count < 1)
            {
                return;
            }
            
            foreach (EntityRef<Soul> entityRef in self.Targets)
            {
                Soul target = entityRef;
                if (target == null ||target.IsDisposed)
                {
                    continue;
                }
                
                // 处于不能被选择状态
                NumericComponent numericComponent = target.GetComponent<NumericComponent>();
                if (numericComponent.GetAsInt(GamePropertyType.GP_CantBeSelected) > 0)
                {
                    continue;
                }

                if (info.HitAction > 0)
                {
                    self.Create(info.HitAction, target, SoulActionTriggerType.CastHit);
                }

                if (info.TargetBuff > 0)
                {
                    target.GetComponent<SoulBuffComponent>()?.Create(info.TargetBuff);
                }
            }
        }

        private static void CastFinish(this SoulCast self)
        {
            
        }
    }
}