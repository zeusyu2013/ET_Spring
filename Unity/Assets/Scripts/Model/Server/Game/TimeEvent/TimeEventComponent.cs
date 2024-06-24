using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf]
    public class TimeEventComponent : Entity, IAwake, IDestroy
    {
        public long Timer;

        public int DayOfYear;

        public Dictionary<int, bool> DailyChecks = new();
    }
}