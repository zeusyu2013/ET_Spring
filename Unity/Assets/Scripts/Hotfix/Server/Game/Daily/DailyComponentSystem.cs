using System;

namespace ET.Server
{
    [EntitySystemOf(typeof(DailyComponent))]
    [FriendOfAttribute(typeof(ET.Server.DailyComponent))]
    public static partial class DailyComponentSystem
    {
        [Invoke(TimerInvokeType.DailyCheckTimer)]
        public class DailyCheckTimer : ATimer<DailyComponent>
        {
            protected override void Run(DailyComponent self)
            {
                self.DailyCheck();
            }
        }

        [EntitySystem]
        private static void Awake(this ET.Server.DailyComponent self)
        {
            TimeInfo.Instance.TimeZone = GlobalDataConfigCategory.Instance.BagCapacity;

            self.DailyCheckTimer = self.Root().GetComponent<TimerComponent>()
                    .NewRepeatedTimer(60 * 1000, TimerInvokeType.DailyCheckTimer, self);
        }

        private static void DailyCheckOne(this DailyComponent self, int activityId)
        {
            if (activityId < 1)
            {
                return;
            }

            if (self.DailyConfigs.Contains(activityId))
            {
                return;
            }

            var config = DailyConfigCategory.Instance.Get(activityId);
            if (config == null)
            {
                return;
            }

            switch (config.DailyType)
            {
                case DailyType.DailyType_Daily:
                {
                    var now = TimeInfo.Instance.ServerNow();
                    if (now >= config.EndTime)
                    {
                        break;
                    }

                    EventSystem.Instance.Publish(self.Root(), new DailyCheck() { ActivityId = config.Id });
                    self.DailyConfigs.Add(config.Id);
                }
                    break;
                case DailyType.DailyType_Weeky:
                {
                }
                    break;
                case DailyType.DailyType_Monthy:
                    break;
                case DailyType.DailyType_Days:
                {
                    var day = TimeInfo.Instance.GetDayOfWeek();
                    if (config.Days.Contains((int)day))
                    {
                        var seconds = TimeInfo.Instance.PassedSecondsOfDay();
                        if (seconds >= config.DateTime)
                        {
                            EventSystem.Instance.Publish(self.Root(), new DailyCheck() { ActivityId = config.Id });
                            self.DailyConfigs.Add(config.Id);
                        }
                    }
                }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static void DailyCheck(this DailyComponent self)
        {
            var configs = DailyConfigCategory.Instance.DataList;
            if (configs.Count < 1)
            {
                return;
            }

            var now = TimeInfo.Instance.ServerNow();
            foreach (DailyConfig config in configs)
            {
                self.DailyCheckOne(config.Id);
            }
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.DailyComponent self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.DailyCheckTimer);

            self.DailyConfigs.Clear();
        }
    }
}