using System.Collections.Generic;

namespace ET.Server
{
    [FriendOf(typeof(RoleInfo))]
    [MessageSessionHandler(SceneType.Gate)]
    public class C2G_GetRolesHandler : MessageSessionHandler<C2G_GetRoles, G2C_GetRoles>
    {
        protected override async ETTask Run(Session session, C2G_GetRoles request, G2C_GetRoles response)
        {
            long playerId = request.PlayerId;

            List<RoleInfo> gameRoleInfos = await session.Root().GetComponent<DBManagerComponent>().GetZoneDB(session.Zone())
                    .Query<RoleInfo>(x => x.PlayerId == playerId);

            List<GameRoleInfo> infos = new();
            foreach (RoleInfo info in gameRoleInfos)
            {
                infos.Add(info.Convert());
            }

            response.Roles = infos;
        }
    }
}