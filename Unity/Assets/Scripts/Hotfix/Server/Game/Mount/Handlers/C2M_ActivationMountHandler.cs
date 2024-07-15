namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_ActivationMountHandler : MessageLocationHandler<Unit, C2M_ActivationMount, M2C_ActivationMount>
    {
        protected override async ETTask Run(Unit unit, C2M_ActivationMount request, M2C_ActivationMount response)
        {
            response.Error = unit.GetComponent<MountComponent>().ActivationMount(request.MountConfigId);
            
            await ETTask.CompletedTask;
        }
    }
}