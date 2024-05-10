namespace ET.Server
{
    [FriendOf(typeof(GameRole))]
    [FriendOf(typeof(GameRoleName))]
    [MessageSessionHandler(SceneType.Gate)]
    public class C2G_CreateRoleHandler : MessageSessionHandler<C2G_CreateRole, G2C_CreateRole>
    {
        protected override async ETTask Run(Session session, C2G_CreateRole request, G2C_CreateRole response)
        {
            string roleName = request.RoleName;
            if (string.IsNullOrEmpty(roleName))
            {
                response.Error = ErrorCode.ERR_CreateRoleNameEmpty;
                response.Message = "创角时名字传空了";
                return;
            }

            long playerId = request.PlayerId;
            if (playerId < 1)
            {
                response.Error = ErrorCode.ERR_PlayerIdEmpty;
                response.Message = "创角时角色id传空了";
                return;
            }

            int characterType = request.CharacterType;
            int raceType = request.RaceType;

            int errorCode = await session.GetComponent<GameRoleComponent>().Create(roleName, characterType, raceType);
            if (errorCode != ErrorCode.ERR_Success)
            {
                response.Error = errorCode;
                return;
            }

            response.Roles = await session.GetComponent<GameRoleComponent>().Query();
        }
    }
}