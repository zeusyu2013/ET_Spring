namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_UpgradeAvocationHandler : MessageLocationHandler<Unit, C2M_UpgradeAvocation>
    {
        protected override async ETTask Run(Unit unit, C2M_UpgradeAvocation message)
        {
            unit.GetComponent<AvocationComponent>().UpgradeAvocation((AvocationType)message.AvocationType);

            await ETTask.CompletedTask;
        }
    }
}