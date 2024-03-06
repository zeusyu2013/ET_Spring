using System.Collections.Generic;

namespace ET.Server
{
    [FriendOf(typeof(RoleInfo))]
    [MessageSessionHandler(SceneType.Gate)]
    public class C2G_DeleteRoleHandler : MessageSessionHandler<C2G_DeleteRole, G2C_DeleteRole>
    {
        protected override async ETTask Run(Session session, C2G_DeleteRole request, G2C_DeleteRole response)
        {
            long playerId = request.PlayerId;
            string roleName = request.RoleName;

            using (await session.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.DeleteRole, playerId))
            {
                List<RoleInfo> roleInfos =
                        await session.Root().GetComponent<DBManagerComponent>().GetZoneDB(session.Zone())
                                .Query<RoleInfo>(x => x.PlayerId == playerId && x.RoleName.Equals(roleName) && !x.Deleted);
                if (roleInfos.Count != 1)
                {
                    response.Error = ErrorCode.ERR_DeleteRoleHasNoRole;
                    response.Message = "删除角色时未找到对应角色";
                    return;
                }

                RoleInfo info = roleInfos[0];
                info.Deleted = true;
                await session.Root().GetComponent<DBManagerComponent>().GetZoneDB(session.Zone()).Save(info);

                roleInfos = await session.Root().GetComponent<DBManagerComponent>().GetZoneDB(session.Zone())
                        .Query<RoleInfo>(x => x.PlayerId == playerId && !x.Deleted);

                List<GameRoleInfo> list = new();
                foreach (RoleInfo roleInfo in roleInfos)
                {
                    list.Add(roleInfo.Convert());
                }

                response.Roles = list;
            }
        }
    }
}