namespace ET.Server
{
    [ChildOf]
    public class RoleNameInfo : Entity, IAwake
    {
        public string RoleName;
        public bool Deleted;
    }
}