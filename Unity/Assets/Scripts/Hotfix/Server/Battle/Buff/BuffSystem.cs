using System;

namespace ET.Server
{
    [EntitySystemOf(typeof(Buff))]
    [FriendOfAttribute(typeof(ET.Server.Buff))]
    public static partial class BuffSystem
    {
        [Invoke(TimerInvokeType.BuffExpiredTimer)]
        public class BuffExpiredTimer : ATimer<Buff>
        {
            protected override void Run(Buff self)
            {
                self.Timeout();
            }
        }

        [EntitySystem]
        private static void Awake(this ET.Server.Buff self, int configId)
        {
            self.ConfigId = configId;
            self.AddComponent<ActionTempComponent>();

            self.CreateTime = TimeInfo.Instance.ServerNow();

            if (self.Config.ContinueTime == 0)
            {
                self.SetExpiredTime(0);
            }
            else
            {
                long expired = self.CreateTime + self.Config.ContinueTime;
                self.SetExpiredTime(expired);
            }

            self.SetTickTime(self.Config.Tick);
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.Buff self)
        {
            self.ConfigId = default;
            self.Owner = default;
            self.CreateTime = default;
            self.TickTime = default;
            self.TickBeginTime = default;

            self.Root().GetComponent<TimerComponent>().Remove(ref self.TickTimer);
            self.Root().GetComponent<TimerComponent>().Remove(ref self.WaitTickTimer);

            self.ExpiredTime = default;
            self.Root().GetComponent<TimerComponent>().Remove(ref self.ExpiredTimer);
        }

        [EntitySystem]
        private static void Deserialize(this ET.Server.Buff self)
        {
            self.AddComponent<ActionTempComponent>();
            self.Owner = self.Parent.GetParent<Unit>();
        }

        public static void SetExpiredTime(this Buff self, long expiredTime, bool notifyClient = false)
        {
            if (expiredTime == 0)
            {
                self.ExpiredTime = 0;
                if (notifyClient)
                {
                    self.NotifyClientUpdateInfo();
                }

                return;
            }

            if (self.ExpiredTime == expiredTime)
            {
                return;
            }

            self.ExpiredTime = expiredTime;
            if (notifyClient)
            {
                self.NotifyClientUpdateInfo();
            }

            if (self.ExpiredTimer != 0)
            {
                self.Root().GetComponent<TimerComponent>().Remove(ref self.ExpiredTimer);
            }

            self.ExpiredTimer = self.Root().GetComponent<TimerComponent>().NewOnceTimer(self.ExpiredTime, TimerInvokeType.BuffExpiredTimer, self);
        }

        public static void NotifyClientUpdateInfo(this Buff self)
        {
            M2C_BuffUpdate m2CBuffUpdate = M2C_BuffUpdate.Create();
            Unit owner = self.Owner;
            m2CBuffUpdate.UnitId = owner.Id;
            m2CBuffUpdate.BuffInfo = self.ToMessage();
            BattleMessageHelper.SendClient(owner, m2CBuffUpdate, self.Config.NotifyType);
        }

        public static void AddActions(this Buff self)
        {
            long instanceId = self.InstanceId;

            foreach (int action in self.Config.AddActions)
            {
                try
                {
                    self.Create(action, ActionTriggerType.BuffAdd);

                    if (self.InstanceId != instanceId)
                    {
                        break;
                    }
                }
                catch (Exception e)
                {
                    Log.Error(
                        $"Buff添加时行为出错， OwnerId:{((Unit)self.Owner)?.Id ?? 0} buffId:{self.Id} buffConfigId:{self.ConfigId} Action:{action} {e}");
                }
            }
        }

        public static void RemoveActions(this Buff self)
        {
            long instanceId = self.InstanceId;

            foreach (int action in self.Config.RemoveActions)
            {
                try
                {
                    self.Create(action, ActionTriggerType.BuffRemove);

                    if (self.InstanceId != instanceId)
                    {
                        break;
                    }
                }
                catch (Exception e)
                {
                    Log.Error(
                        $"Buff移除时行为出错， OwnerId:{((Unit)self.Owner)?.Id ?? 0} buffId:{self.Id} buffConfigId:{self.ConfigId} Action:{action} {e}");
                }
            }
        }

        public static void TickActions(this Buff self)
        {
            if (self.IsDisposed)
            {
                return;
            }

            long instanceId = self.InstanceId;

            foreach (int action in self.Config.TickActions)
            {
                try
                {
                    self.Create(action, ActionTriggerType.BuffTick);

                    if (self.InstanceId != instanceId)
                    {
                        break;
                    }
                }
                catch (Exception e)
                {
                    if (instanceId == self.InstanceId)
                    {
                        Log.Error(
                            $"Buff循环执行时行为出错， OwnerId:{((Unit)self.Owner)?.Id ?? 0} buffId:{self.Id} buffConfigId:{self.ConfigId} Action:{action} {e}");
                    }
                    else
                    {
                        Log.Error($"Buff InstanceId 不同 buffConfigId:{self.ConfigId} Action:{action} {e}");
                    }
                }
            }

            if (self.InstanceId != instanceId)
            {
                return;
            }

            Unit owner = self.Owner;
            if (self.Config.TickActions.Count > 0)
            {
                if (owner == null)
                {
                    return;
                }

                M2C_BuffTick m2CBuffTick = M2C_BuffTick.Create();
                m2CBuffTick.UnitId = owner.Id;
                m2CBuffTick.BuffId = self.Id;
                BattleMessageHelper.SendClient(owner, m2CBuffTick, self.Config.NotifyType);
            }
        }

        public static BuffInfo ToMessage(this Buff self)
        {
            BuffInfo info = BuffInfo.Create();
            info.Id = self.Id;
            info.ConfigId = self.ConfigId;
            info.CreateTime = self.CreateTime;
            info.ExpiredTime = self.ExpiredTime;

            return info;
        }

        public static void Timeout(this Buff self)
        {
            EventSystem.Instance.Publish(self.Scene(), new BuffTimeout()
            {
                Unit = self.Owner,
                BuffId = self.Id
            });
        }

        [Invoke(TimerInvokeType.BuffTickTimer)]
        public class BuffTickTimer : ATimer<Buff>
        {
            protected override void Run(Buff self)
            {
            }
        }

        public static void SetTickTime(this Buff self, int tickTime)
        {
            if (tickTime < 1)
            {
                Log.Error($"Buff 生效间隔为0 请检查配置 buff Config:{self.ConfigId}");
                return;
            }

            self.TickBeginTime = TimeInfo.Instance.ServerNow();
            self.TickTime = tickTime;
            self.Root().GetComponent<TimerComponent>().Remove(ref self.TickTimer);

            self.TickTimer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(tickTime, TimerInvokeType.BuffTickTimer, self);
        }
    }
}