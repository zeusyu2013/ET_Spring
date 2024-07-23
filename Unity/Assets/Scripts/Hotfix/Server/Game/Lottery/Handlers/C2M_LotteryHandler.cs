namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_LotteryHandler : MessageLocationHandler<Unit, C2M_Lottery, M2C_Lottery>
    {
        protected override async ETTask Run(Unit unit, C2M_Lottery request, M2C_Lottery response)
        {
            unit.GetComponent<LotteryComponent>().Do();
            
            await ETTask.CompletedTask;
        }
    }
}