using System.Collections.Generic;

namespace ET.Server
{
    [FriendOf(typeof(RoleInfo))]
    [FriendOf(typeof(RoleNameInfo))]
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

            using (await session.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.CreateRole, playerId))
            {
                // 查询重名
                List<RoleNameInfo> roleNameInfos = await session.Root().GetComponent<DBManagerComponent>().GetZoneDB(session.Zone())
                        .Query<RoleNameInfo>(x => x.RoleName.Equals(roleName));

                bool sameName = false;
                foreach (RoleNameInfo info in roleNameInfos)
                {
                    if (!info.Deleted)
                    {
                        sameName = true;
                    }
                }

                // 重名提示
                if (sameName)
                {
                    response.Error = ErrorCode.ERR_CreateRoleNameSame;
                    return;
                }

                // 开始创角流程
                RoleInfo roleInfo = session.Root().GetComponent<GameRoleComponent>().AddChild<RoleInfo>();
                roleInfo.PlayerId = playerId;
                roleInfo.RoleName = roleName;
                roleInfo.RoleLevel = 1;

                await session.Root().GetComponent<DBManagerComponent>().GetZoneDB(session.Zone()).Save(roleInfo);

                // 存储名字
                RoleNameInfo roleNameInfo = session.Root().GetComponent<RoleNameComponent>().AddChild<RoleNameInfo>();
                roleNameInfo.RoleName = roleName;
                roleNameInfo.Deleted = false;
                await session.Root().GetComponent<DBManagerComponent>().GetZoneDB(session.Zone()).Save(roleNameInfo);

                // 重新查询角色列表，并返回
                List<RoleInfo> roleInfos = await session.Root().GetComponent<DBManagerComponent>().GetZoneDB(session.Zone())
                        .Query<RoleInfo>(x => x.PlayerId == playerId);

                List<GameRoleInfo> list = new();
                foreach (RoleInfo info in roleInfos)
                {
                    list.Add(info.Convert());
                }

                response.Roles = list;
            }
        }
    }
}