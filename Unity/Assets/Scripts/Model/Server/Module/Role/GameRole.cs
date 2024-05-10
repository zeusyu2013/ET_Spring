namespace ET.Server
{
    [ChildOf(typeof(GameRoleComponent))]
    public class GameRole : Entity, IAwake, ISerializeToEntity
    {
        public long PlayerId;
        public string RoleName;
        public int RoleLevel;
        public int CharacterType;
        public int RaceType;
        public string RoleModel;
        public bool Deleted;
    }
}