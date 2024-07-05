namespace ET.Server
{
    [FriendOf(typeof(GameRole))]
    [MessageSessionHandler(SceneType.Gate)]
    public class C2G_GetRolesHandler : MessageSessionHandler<C2G_GetRoles, G2C_GetRoles>
    {
        protected override async ETTask Run(Session session, C2G_GetRoles request, G2C_GetRoles response)
        {
            response.Roles = await session.GetComponent<GameRoleComponent>().Query();
        }
    }
}