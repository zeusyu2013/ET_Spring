namespace ET.Server
{
    [ComponentOf(typeof(Unit))]
    public class MonsterComponent : Entity, IAwake<int>, IDestroy
    {
        public int ConfigId;
    }
}