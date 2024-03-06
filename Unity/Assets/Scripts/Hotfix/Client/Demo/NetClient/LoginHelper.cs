namespace ET.Client
{
    public static class LoginHelper
    {
        public static async ETTask Login(Scene root, string account, string password)
        {
            ClientSenderComponent clientSenderComponent = root.GetComponent<ClientSenderComponent>();
            if (clientSenderComponent != null)
            {
                await clientSenderComponent.DisposeAsync();
            }

            clientSenderComponent = root.AddComponent<ClientSenderComponent>();

            long playerId = await clientSenderComponent.LoginAsync(account, password);

            root.GetComponent<PlayerComponent>().MyId = playerId;

            await EventSystem.Instance.PublishAsync(root, new LoginFinish());
        }

        public static async ETTask<int> GetRoleInfos(Scene root)
        {
            PlayerComponent playerComponent = root.GetComponent<PlayerComponent>();
            long playerId = playerComponent.MyId;
            if (playerId < 1)
            {
                return ErrorCode.ERR_PlayerIdEmpty;
            }

            C2G_GetRoles c2GGetRoles = C2G_GetRoles.Create();
            c2GGetRoles.PlayerId = playerId;

            G2C_GetRoles g2CGetRoles = await SessionHelper.Call<G2C_GetRoles>(root, c2GGetRoles);
            if (g2CGetRoles.Error != ErrorCode.ERR_Success)
            {
                Log.Error($"获取角色列表失败：{g2CGetRoles.Message}");
                return g2CGetRoles.Error;
            }
            
            // 清空客户端列表，重新获取
            GameRoleInfoComponent gameRoleInfoComponent = root.GetComponent<GameRoleInfoComponent>();
            gameRoleInfoComponent.ClearInfos();
            
            foreach (GameRoleInfo info in g2CGetRoles.Roles)
            {
                gameRoleInfoComponent.AddGameRoleInfo(info);
            }

            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> CreateRole(Scene root, string roleName, int roleJob)
        {
            PlayerComponent playerComponent = root.GetComponent<PlayerComponent>();
            long playerId = playerComponent.MyId;
            if (playerId < 1)
            {
                return ErrorCode.ERR_PlayerIdEmpty;
            }

            C2G_CreateRole c2GCreateRole = C2G_CreateRole.Create();
            c2GCreateRole.PlayerId = playerId;
            c2GCreateRole.RoleName = roleName;
            c2GCreateRole.RoleJob = roleJob;

            G2C_CreateRole g2CCreateRole = await SessionHelper.Call<G2C_CreateRole>(root, c2GCreateRole);
            if (g2CCreateRole.Error != ErrorCode.ERR_Success)
            {
                Log.Error($"获取角色列表失败：{g2CCreateRole.Message}");
                return g2CCreateRole.Error;
            }
            
            // 清空客户端列表，重新获取
            GameRoleInfoComponent gameRoleInfoComponent = root.GetComponent<GameRoleInfoComponent>();
            gameRoleInfoComponent.ClearInfos();
            
            foreach (GameRoleInfo info in g2CCreateRole.Roles)
            {
                gameRoleInfoComponent.AddGameRoleInfo(info);
            }

            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> DeleteRole(Scene root, string roleName)
        {
            PlayerComponent playerComponent = root.GetComponent<PlayerComponent>();
            long playerId = playerComponent.MyId;
            if (playerId < 1)
            {
                return ErrorCode.ERR_PlayerIdEmpty;
            }

            C2G_DeleteRole c2GDeleteRole = C2G_DeleteRole.Create();
            c2GDeleteRole.PlayerId = playerId;
            c2GDeleteRole.RoleName = roleName;
            G2C_DeleteRole g2CDeleteRole = await SessionHelper.Call<G2C_DeleteRole>(root, c2GDeleteRole);
            if (g2CDeleteRole.Error != ErrorCode.ERR_Success)
            {
                Log.Error($"获取角色列表失败：{g2CDeleteRole.Message}");
                return g2CDeleteRole.Error;
            }
            
            // 清空客户端列表，重新获取
            GameRoleInfoComponent gameRoleInfoComponent = root.GetComponent<GameRoleInfoComponent>();
            gameRoleInfoComponent.ClearInfos();
            
            foreach (GameRoleInfo info in g2CDeleteRole.Roles)
            {
                gameRoleInfoComponent.AddGameRoleInfo(info);
            }

            return ErrorCode.ERR_Success;
        }
    }
}