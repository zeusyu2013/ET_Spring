namespace ET.Server
{
    [ComponentOf(typeof(Unit))]
    public class BattleProgressComponent : Entity, IAwake, IDestroy
    {
        public int Progress;
        
        public int TotalProgress;

        public long StartTime;
    }
}