using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf]
    public class DailyComponent : Entity, IAwake, IDestroy
    {
        public long DailyCheckTimer;
        
        public List<int> DailyConfigs = new();
    }
}