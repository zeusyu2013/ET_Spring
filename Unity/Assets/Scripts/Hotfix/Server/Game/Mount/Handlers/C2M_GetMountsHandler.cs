namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    [FriendOfAttribute(typeof(ET.Server.MountComponent))]
    public class C2M_GetMountsHandler : MessageLocationHandler<Unit, C2M_GetMounts, M2C_GetMounts>
    {
        protected override async ETTask Run(Unit unit, C2M_GetMounts request, M2C_GetMounts response)
        {
            response.Mounts = unit.GetComponent<MountComponent>().Mounts;

            await ETTask.CompletedTask;
        }
    }
}