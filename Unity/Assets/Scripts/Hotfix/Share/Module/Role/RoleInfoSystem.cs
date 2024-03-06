namespace ET
{
    [FriendOf(typeof(RoleInfo))]
    [EntitySystemOf(typeof(RoleInfo))]
    public static partial class RoleInfoSystem
    {
        [EntitySystem]
        public static void Awake(this RoleInfo self)
        {
        }

        public static GameRoleInfo Convert(this RoleInfo self)
        {
            GameRoleInfo info = GameRoleInfo.Create();
            info.PlayerId = self.PlayerId;
            info.RoleName = self.RoleName;
            info.RoleLevel = self.RoleLevel;

            return info;
        }
    }
}