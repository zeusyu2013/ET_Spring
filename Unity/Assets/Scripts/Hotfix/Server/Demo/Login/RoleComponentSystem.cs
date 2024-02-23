namespace ET
{
    [EntitySystemOf(typeof(RoleComponent))]
    [FriendOfAttribute(typeof(ET.RoleInfo))]
    [FriendOfAttribute(typeof(ET.RoleComponent))]
    public static partial class RoleComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.RoleComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ET.RoleComponent self)
        {
        }

        public static void AddRole(this RoleComponent self, GameRoleInfo info)
        {
            RoleInfo roleInfo = self.AddChildWithId<RoleInfo>(info.PlayerId);
            roleInfo.PlayerId = info.PlayerId;
            roleInfo.RoleName = info.RoleName;
            roleInfo.RoleLevel = info.RoleLevel;
            roleInfo.RoleJob = info.RoleJob;
            roleInfo.RoleModel = info.RoleModel;

            self.RoleInfos.Add(roleInfo);
        }

        public static void ClearRoleInfo(this RoleComponent self)
        {
            foreach (RoleInfo info in self.RoleInfos)
            {
                info?.Dispose();
            }
            
            self.RoleInfos.Clear();
        }
    }
}