namespace ET.Server
{
    public class Buff : Entity, IAwake<int>, IDestroy, ISerializeToEntity
    {
        public int ConfigId;
    }
}