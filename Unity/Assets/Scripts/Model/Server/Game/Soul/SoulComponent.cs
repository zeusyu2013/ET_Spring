namespace ET.Server
{
    [UnitCacheEvent(typeof(SoulComponent))]
    [ComponentOf(typeof(Unit))]
    public class SoulComponent : Entity, IAwake, IDestroy, IDeserialize
    {
    }
}