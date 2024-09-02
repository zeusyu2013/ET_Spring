﻿namespace ET.Server
{
    [EntitySystemOf(typeof(Cast))]
    [FriendOfAttribute(typeof(ET.Server.Cast))]
    public static partial class CastSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.Cast self, int configId)
        {
            self.ConfigId = configId;
            self.AddComponent<ActionTempComponent>();
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.Cast self)
        {
            self.ConfigId = default;
            self.Caster = default;
            self.Targets.Clear();
            self.StartTime = default;
        }

        public static int Cast(this Cast self)
        {
            int err = self.CastCheck();
            if (err != ErrorCode.ERR_Success)
            {
                return err;
            }

            self.SelectTargets();

            err = self.CastCheckBeforeBegin();
            if (err != ErrorCode.ERR_Success)
            {
                return err;
            }

            self.CastBeginAsync().Coroutine();

            return ErrorCode.ERR_Success;
        }

        private static int CastCheck(this Cast self)
        {
            if (self == null || self.IsDisposed)
            {
                return ErrorCode.ERR_CastIsNull;
            }

            Unit caster = self.Caster;
            if (caster == null || caster.IsDisposed)
            {
                return ErrorCode.ERR_CasterError;
            }

            return ErrorCode.ERR_Success;
        }

        private static void SelectTargets(this Cast self)
        {
            //self.Targets.Clear();

            Unit caster = self.Caster;

            int errorCode = SelectTargetHelper.Select(caster, self.Config.SelectTargetType, self.Config.SelectTargetsParams, ref self.Targets);
            if (errorCode != ErrorCode.ERR_Success)
            {
                Log.Error($"选择目标时错误，错误码：{errorCode}");
            }
        }

        private static int CastCheckBeforeBegin(this Cast self)
        {
            if (self.Targets.Count < 1)
            {
                return ErrorCode.ERR_CastNoTarget;
            }

            return ErrorCode.ERR_Success;
        }

        private static async ETTask CastBeginAsync(this Cast self)
        {
            Unit caster = self.Caster;

            bool needBreak = caster.GetComponent<SkillStatusComponent>().Casting(self);
            if (!needBreak)
            {
                self.BreakCasting();
                return;
            }

            self.StartTime = TimeInfo.Instance.ServerNow();

            M2C_CastStart m2CCastStart = M2C_CastStart.Create();
            m2CCastStart.CastId = self.Id;

            m2CCastStart.CasterId = caster.Id;
            m2CCastStart.CastConfigId = self.ConfigId;
            m2CCastStart.Targets = self.Targets;

            BattleMessageHelper.SendClient(caster, m2CCastStart, self.Config.NotifyType);

            if (self.Config.HitInfos.Count < 1)
            {
                return;
            }

            long castInstanceId = 0;
            long casterInstanceId = 0;

            foreach (CastHitInfo info in self.Config.HitInfos)
            {
                castInstanceId = self.InstanceId;
                casterInstanceId = caster.InstanceId;

                await self.Root().GetComponent<TimerComponent>().WaitTillAsync(self.StartTime + info.Time);

                if (!self.CheckAsyncInvalid(castInstanceId, casterInstanceId))
                {
                    Log.Error($"异步检测失败，{castInstanceId} {casterInstanceId}");
                    return;
                }

                if (info.HitSelf)
                {
                    self.HandleSelfHit(info);
                }
                else
                {
                    self.HandleTargetHit(info);
                }
            }

            if (self.Config.TotalTime > 0)
            {
                castInstanceId = self.InstanceId;
                casterInstanceId = caster.InstanceId;

                await self.Root().GetComponent<TimerComponent>().WaitTillAsync(self.StartTime + self.Config.TotalTime);

                if (!self.CheckAsyncInvalid(castInstanceId, casterInstanceId))
                {
                    Log.Error($"异步检测失败，{castInstanceId} {casterInstanceId}");
                    return;
                }
            }

            self.CastFinish();
        }

        private static void HandleSelfHit(this Cast self, CastHitInfo hitInfo)
        {
            self.SelectTargets();
            if (self.Targets.Count < 1)
            {
                return;
            }

            Unit caster = self.Caster;

            M2C_CastHit m2CCastHit = M2C_CastHit.Create();
            m2CCastHit.CastId = self.Id;
            m2CCastHit.CasterId = caster.Id;
            m2CCastHit.Targets = self.Targets;
            BattleMessageHelper.SendClient(caster, m2CCastHit, self.Config.NotifyType);

            if (hitInfo.HitAction > 0)
            {
                self.Create(hitInfo.HitAction, self.Caster, ActionTriggerType.CastHit);
            }

            if (hitInfo.SelfBuff > 0)
            {
                caster.GetComponent<BuffComponent>()?.CreateAndAdd(hitInfo.SelfBuff);
            }
        }

        private static void HandleTargetHit(this Cast self, CastHitInfo info)
        {
            self.SelectTargets();

            if (self.Targets.Count < 1)
            {
                return;
            }

            M2C_CastHit m2CCastHit = M2C_CastHit.Create();
            m2CCastHit.CastId = self.Id;
            Unit caster = self.Caster;
            m2CCastHit.CasterId = caster.Id;
            m2CCastHit.Targets = self.Targets;
            BattleMessageHelper.SendClient(caster, m2CCastHit, self.Config.NotifyType);

            UnitComponent unitComponent = caster.Root().GetComponent<UnitComponent>();
            foreach (long id in self.Targets)
            {
                Unit target = unitComponent.Get(id);
                if (target == null || target.IsDisposed)
                {
                    continue;
                }

                // 处于不能被选择状态
                if (target.GetInt(GamePropertyType.GP_CantBeSelected) > 0)
                {
                    continue;
                }

                if (info.HitAction > 0)
                {
                    self.Create(info.HitAction, target, ActionTriggerType.CastHit);
                }

                if (info.TargetBuff > 0)
                {
                    target.GetComponent<BuffComponent>()?.CreateAndAdd(info.TargetBuff);
                }
            }
        }

        private static void CastFinish(this Cast self)
        {
            Unit caster = self.Caster;

            bool needBreak = caster.GetComponent<SkillStatusComponent>().Finish(self);
            if (!needBreak)
            {
                self.BreakCasting();
                return;
            }

            if (self.Config.TotalTime > 0)
            {
                M2C_CastFinish m2CCastFinish = M2C_CastFinish.Create();
                m2CCastFinish.CastId = self.Id;
                m2CCastFinish.CasterId = caster.Id;
                BattleMessageHelper.SendClient(caster, m2CCastFinish, self.Config.NotifyType);
            }

            if (self.Config.FinishActions.Count > 0)
            {
                foreach (int action in self.Config.FinishActions)
                {
                    self.Create(action, caster, ActionTriggerType.CastFinish);
                }
            }

            self?.Dispose();
        }

        private static bool CheckAsyncInvalid(this Cast self, long castInstanceId, long casterInstanceId)
        {
            Unit unit = self.Caster;
            if (unit == null)
            {
                return false;
            }

            if (self.InstanceId != castInstanceId || unit.InstanceId != casterInstanceId)
            {
                return false;
            }

            return true;
        }

        private static void BreakCasting(this Cast self)
        {
            Unit caster = self.Caster;

            M2C_CastBreak m2CCastBreak = M2C_CastBreak.Create();
            m2CCastBreak.CastId = self.Id;
            m2CCastBreak.CasterId = caster.Id;
            BattleMessageHelper.SendClient(caster, m2CCastBreak, self.Config.NotifyType);

            self.Dispose();
        }
    }
}