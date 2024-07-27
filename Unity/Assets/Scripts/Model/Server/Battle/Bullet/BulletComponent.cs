namespace ET.Server
{
    public class BulletComponent : Entity, IAwake<int>, IDestroy
    {
        public int ConfigId;

        public long OwnerId;
    }
}