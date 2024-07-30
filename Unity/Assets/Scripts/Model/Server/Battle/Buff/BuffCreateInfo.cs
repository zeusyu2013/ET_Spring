namespace ET.Server
{
    [ChildOf(typeof(BuffTempComponent))]
    public class BuffCreateInfo : Entity, IAwake<int>, IDestroy, ISerializeToEntity
    {
        public int ConfigId;
    }
}