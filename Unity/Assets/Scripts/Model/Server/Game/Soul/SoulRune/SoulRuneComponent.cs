namespace ET.Server
{
    [ComponentOf(typeof(Soul))]
    public class SoulRuneComponent : Entity, IAwake, IDestroy, ISerializeToEntity, IDeserialize
    {
    }
}