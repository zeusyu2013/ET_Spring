namespace ET.Server
{
    [ComponentOf]
    public class DungeonTimeComponent : Entity, IAwake<long>, IDestroy
    {
        public long During;

        public long Timer;
    }
}