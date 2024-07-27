namespace ET.Server
{
    public class Cast : Entity, IAwake<int>, IDestroy
    {
        public int ConfigId;

        public EntityRef<Unit> Caster;
    }
}