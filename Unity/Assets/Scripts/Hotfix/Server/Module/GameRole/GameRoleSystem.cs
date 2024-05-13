namespace ET.Server
{
    [EntitySystemOf(typeof(GameRole))]
    [FriendOfAttribute(typeof(ET.Server.GameRole))]
    public static partial class GameRoleSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.GameRole self)
        {
        }

        public static GameRoleInfo ToMessage(this GameRole self)
        {
            GameRoleInfo info = GameRoleInfo.Create();
            info.UnitId = self.UnitId;
            info.RoleName = self.RoleName;
            info.RoleLevel = self.RoleLevel;
            info.CharacterType = self.CharacterType;
            info.RaceType = self.RaceType;
            info.RoleModel = self.RoleModel;

            return info;
        }
    }
}