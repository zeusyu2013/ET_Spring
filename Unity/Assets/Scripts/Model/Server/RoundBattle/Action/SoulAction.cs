namespace ET.Server
{
    [ChildOf(typeof(SoulActionComponent))]
    public class SoulAction : Entity, IAwake<int>, IDestroy
    {
        public int ConfigId;

        public SoulActionConfig Config => SoulActionConfigCategory.Instance.Get(this.ConfigId);

        public EntityRef<Soul> Caster;

        public EntityRef<Soul> Owner;

        public SoulCast Cast => this.Parent.GetParent<SoulCast>();

        public SoulBuff Buff => this.Parent.GetParent<SoulBuff>();
    }
}