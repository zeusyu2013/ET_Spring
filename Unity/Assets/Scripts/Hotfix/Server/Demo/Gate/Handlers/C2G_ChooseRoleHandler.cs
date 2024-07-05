namespace ET.Server
{
    [MessageSessionHandler(SceneType.Gate)]
    public class C2G_ChooseRoleHandler: MessageSessionHandler<C2G_ChooseRole, G2C_ChooseRole>
    {
        protected override async ETTask Run(Session session, C2G_ChooseRole request, G2C_ChooseRole response)
        {
            string roleName = request.RoleName;
            if (string.IsNullOrEmpty(roleName))
            {
                response.Error = ErrorCode.ERR_CreateRoleNameEmpty;
                response.Message = "选择角色时名字传空了";
                return;
            }
            
            long playerId = request.PlayerId;
            if (playerId < 1)
            {
                response.Error = ErrorCode.ERR_PlayerIdEmpty;
                response.Message = "选择角色时角色id传空了";
                return;
            }

            using (await session.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.GameRole, playerId))
            {
                
            }
        }
    }
}