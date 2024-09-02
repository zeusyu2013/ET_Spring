namespace ET.Client
{
    public static class LoginHelper
    {
        public static async ETTask Login(Scene root, string account, string password, string host, int port)
        {
            root.RemoveComponent<ClientSenderComponent>();

            ClientSenderComponent clientSenderComponent = root.AddComponent<ClientSenderComponent>();

            var (playerId, UnitId) = await clientSenderComponent.LoginAsync(account, password, host, port);
            // 
            root.GetComponent<PlayerComponent>().MyId = playerId;
            
            await EventSystem.Instance.PublishAsync(root, new LoginFinish(){UnitId = UnitId});
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
            ClientSenderComponent clientSenderComponent = root.GetComponent<ClientSenderComponent>();
            G2C_GetRoles g2CGetRoles = await clientSenderComponent.Call(c2GGetRoles) as G2C_GetRoles;
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

        public static async ETTask<int> CreateRole(Scene root, string roleName, int character, int race)
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
            c2GCreateRole.CharacterType = character;
            c2GCreateRole.RaceType = race;
            ClientSenderComponent clientSenderComponent = root.GetComponent<ClientSenderComponent>();
            
            G2C_CreateRole g2CCreateRole = await clientSenderComponent.Call(c2GCreateRole) as G2C_CreateRole;
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

        public static async ETTask<int> ChooseRole(Scene root, string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
            {
                return ErrorCode.ERR_ChooseRoleNameEmpty;
            }
            
            PlayerComponent playerComponent = root.GetComponent<PlayerComponent>();
            long playerId = playerComponent.MyId;
            if (playerId < 1)
            {
                return ErrorCode.ERR_PlayerIdEmpty;
            }

            C2G_ChooseRole c2GChooseRole = C2G_ChooseRole.Create();
            c2GChooseRole.PlayerId = playerId;
            c2GChooseRole.RoleName = roleName;
            G2C_ChooseRole g2CChooseRole = await SessionHelper.Call<G2C_ChooseRole>(root, c2GChooseRole);
            if (g2CChooseRole.Error != ErrorCode.ERR_Success)
            {
                Log.Error($"选择角色登录异常：{g2CChooseRole.Message}");
                return g2CChooseRole.Error;
            }

            return ErrorCode.ERR_Success;
        }
    }
}