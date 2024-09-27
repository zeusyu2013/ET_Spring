namespace ET.Server
{
    [UnitCacheEvent(typeof(KeyMapComponent))]
    [ComponentOf(typeof(Unit))]
    public class KeyMapComponent : Entity, IAwake, IDestroy
    {
    }
}