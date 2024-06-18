namespace ET.Server
{
    [ComponentOf(typeof(Unit))]
    public class TeamTag : Entity, IAwake<long>, IDestroy
    {
        public long TeamId;
    }
}