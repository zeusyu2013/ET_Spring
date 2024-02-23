namespace ET
{
    [ChildOf]
    public class RoleInfo: Entity, IAwake
    {
        public long PlayerId;
        
        public string RoleName;

        public int RoleLevel;

        public int RoleJob;

        public string RoleModel;
    }
}