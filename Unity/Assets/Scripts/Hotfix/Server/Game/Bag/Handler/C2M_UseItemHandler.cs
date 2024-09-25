namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_UseItemHandler : MessageLocationHandler<Unit, C2M_UseItem>
    {
        protected override async ETTask Run(Unit unit, C2M_UseItem message)
        {
            unit.GetComponent<BagComponent>().UseItem(message.ConfigId, message.Amount);

            await ETTask.CompletedTask;
        }
    }
}