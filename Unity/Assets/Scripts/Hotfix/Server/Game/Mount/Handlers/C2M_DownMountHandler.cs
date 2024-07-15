namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_DownMountHandler : MessageLocationHandler<Unit, C2M_GetMounts, M2C_GetMounts>
    {
        protected override async ETTask Run(Unit unit, C2M_GetMounts request, M2C_GetMounts response)
        {
            unit.GetComponent<MountComponent>().Down();
            
            await ETTask.CompletedTask;
        }
    }
}