namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_LearnAvocationHandler : MessageLocationHandler<Unit, C2M_LearnAvocation>
    {
        protected override async ETTask Run(Unit unit, C2M_LearnAvocation message)
        {
            unit.GetComponent<AvocationComponent>().LearnAvocation((AvocationType)message.AvocationType);

            await ETTask.CompletedTask;
        }
    }
}