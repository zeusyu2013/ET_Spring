namespace ET.Server
{
    [ComponentOf]
    [UnitCacheEvent(typeof(LocationComponent))]
    public class LocationComponent : Entity, IAwake, IDestroy, ITransfer
    {
        public string SceneName;
    }
}