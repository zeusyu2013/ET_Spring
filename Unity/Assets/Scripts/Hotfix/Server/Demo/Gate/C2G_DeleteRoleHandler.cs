using System.Collections.Generic;

namespace ET.Server
{
    [FriendOf(typeof(GameRole))]
    [MessageSessionHandler(SceneType.Gate)]
    public class C2G_DeleteRoleHandler : MessageSessionHandler<C2G_DeleteRole, G2C_DeleteRole>
    {
        protected override async ETTask Run(Session session, C2G_DeleteRole request, G2C_DeleteRole response)
        {
            string roleName = request.RoleName;

            int errorCode = await session.GetComponent<GameRoleComponent>().Delete(roleName);
            if (errorCode != ErrorCode.ERR_Success)
            {
                response.Error = errorCode;
                return;
            }

            response.Roles = await session.GetComponent<GameRoleComponent>().Query();
        }
    }
}