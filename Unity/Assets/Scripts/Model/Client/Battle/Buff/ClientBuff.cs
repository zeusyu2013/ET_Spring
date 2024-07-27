namespace ET.Client
{
    [ChildOf]
    public class ClientBuff : Entity, IAwake<int>, IDestroy
    {
        public int ConfigId;

        public BuffConfig Config => BuffConfigCategory.Instance.Get(this.ConfigId);

        public EntityRef<Unit> Owner;

        public long CreateTime;

        public long ExpiredTime;
    }
}