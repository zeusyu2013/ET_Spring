using System.Collections.Generic;

namespace ET.Server
{
    [EntitySystemOf(typeof(TimeEventComponent))]
    [FriendOfAttribute(typeof(ET.Server.TimeEventComponent))]
    public static partial class TimeEventComponentSystem
    {
        [Invoke(TimerInvokeType.DailyCheckTimer)]
        public class DailyCheckTimer : ATimer<TimeEventComponent>
        {
            protected override void Run(TimeEventComponent self)
            {
                self.DailyCheck();
            }
        }

        [EntitySystem]
        private static void Awake(this ET.Server.TimeEventComponent self)
        {
            TimeInfo.Instance.TimeZone = GlobalDataConfigCategory.Instance.TimeZone;
            self.DayOfYear = TimeInfo.Instance.DayOfYear();
            self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(1000, TimerInvokeType.DailyCheckTimer, self);
        }

        private static void DailyCheck(this TimeEventComponent self)
        {
            int dayOfYear = TimeInfo.Instance.DayOfYear();
            if (self.DayOfYear != dayOfYear)
            {
                self.DayOfYear = dayOfYear;
                
                self.DailyChecks.Clear();
            }
            
            long nowTime = TimeInfo.Instance.PassedSecondsOfToday();

            foreach (DailyConfig dailyConfig in DailyConfigCategory.Instance.DataList)
            {
                if (self.DailyChecks.TryGetValue(dailyConfig.Id, out bool open) && open == false)
                {
                    continue;
                }

                long startTime = TimeInfo.Instance.PassedSecondsOfToday(dailyConfig.StartTime);
                long endTime = TimeInfo.Instance.PassedSecondsOfToday(dailyConfig.EndTime);
                if (startTime >= nowTime && endTime < nowTime)
                {
                    DailyNotify notify = DailyNotify.Create();
                    notify.DailyConfig = dailyConfig.Id;
                    notify.OpenOrClose = true;
                    self.Boardcast(notify);
                    self.DailyChecks.Add(dailyConfig.Id, true);
                }

                if (nowTime > endTime)
                {
                    DailyNotify notify = DailyNotify.Create();
                    notify.DailyConfig = dailyConfig.Id;
                    notify.OpenOrClose = false;
                    self.Boardcast(notify);
                    self.DailyChecks.Add(dailyConfig.Id, false);
                }
            }
        }

        private static void Boardcast(this TimeEventComponent self, IMessage message)
        {
            List<StartSceneConfig> maps = StartSceneConfigCategory.Instance.Maps;

            foreach (StartSceneConfig map in maps)
            {
                MapMessageHelper.Send(self.Root(), map.ActorId, message);
            }
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.TimeEventComponent self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);

            self.DailyChecks.Clear();
        }
    }
}