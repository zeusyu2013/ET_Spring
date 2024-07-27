namespace ET.Server
{
    [UnitCacheEvent(typeof(BuffComponent))]
    public class BuffComponent : Entity, IAwake, IDestroy, ITransfer
    {
    }
}