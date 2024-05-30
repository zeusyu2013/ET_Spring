using ThinkingData.Analytics;

namespace ET.Server
{
    [ComponentOf]
    public class ThinkingDataComponent : Entity, IAwake<string>, IDestroy
    {
        public TDAnalytics TDAnalytics;
    }
}