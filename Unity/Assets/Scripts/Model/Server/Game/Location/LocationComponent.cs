namespace ET.Server
{
    [ComponentOf]
    public class LocationComponent : Entity, IAwake, IDestroy, IUnitCache, ITransfer
    {
        public string SceneName;
    }
}