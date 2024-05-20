namespace ET.Server
{
    [UnitCacheEvent(typeof(DailySigninComponent))]
    [ComponentOf(typeof(Unit))]
    public class DailySigninComponent : Entity, IAwake, IDestroy, IUnitCache
    {
        public int SigninDay;
    }
}