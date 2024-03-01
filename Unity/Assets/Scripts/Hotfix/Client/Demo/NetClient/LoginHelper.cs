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
            G2C_GetRoles g2CGetRoles = (G2C_GetRoles)await root.GetComponent<SessionComponent>().Session.Call(C2G_GetRoles.Create());
            if (g2CGetRoles.Error != ErrorCode.ERR_Success)
            {
                Log.Error($"获取角色列表失败：{g2CGetRoles.Message}");
                return g2CGetRoles.Error;
            }
            
            root.GetComponent<RoleComponent>().ClearRoleInfo();
            
            foreach (GameRoleInfo gameRoleInfo in g2CGetRoles.Roles)
            {
                root.GetComponent<RoleComponent>().AddRole(gameRoleInfo);
            }

            return ErrorCode.ERR_Success;
        }
    }
}