namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_GetHatredHandler : MessageLocationHandler<Unit, C2M_GetHatred, M2C_GetHatred>
    {
        protected override async ETTask Run(Unit unit, C2M_GetHatred request, M2C_GetHatred response)
        {
            UnitComponent unitComponent = unit.Scene().GetComponent<UnitComponent>();

            Unit target = unitComponent.Get(request.UnitId);
            if (target == null)
            {
                return;
            }

            HatredComponent hatredComponent = target.GetComponent<HatredComponent>();
            if (hatredComponent == null)
            {
                return;
            }

            response.HatredInfos = hatredComponent.ToMessage();

            await ETTask.CompletedTask;
        }
    }
}