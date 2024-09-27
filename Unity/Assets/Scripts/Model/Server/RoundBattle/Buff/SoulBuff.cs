namespace ET.Server
{
    [ChildOf]
    public class SoulBuff : Entity, IAwake<int>, IDestroy
    {
        public int ConfigId;

        public SoulBuffConfig Config => SoulBuffConfigCategory.Instance.Get(this.ConfigId);

        public EntityRef<Soul> Owner;

        public int Round;
    }
}