namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class G2M_SessionDisconnectHandler : MessageLocationHandler<Unit, G2M_SessionDisconnect>
    {
        protected override async ETTask Run(Unit unit, G2M_SessionDisconnect message)
        {
            Other2DBCache_SaveUnit request = Other2DBCache_SaveUnit.Create();
            request.Unit = unit.ToBson();

            StartSceneConfig dbcacheSceneConfig = StartSceneConfigCategory.Instance.DBCache;
            unit.Root().GetComponent<MessageSender>().Send(dbcacheSceneConfig.ActorId, request);
            
            unit.Root().GetComponent<UnitComponent>().Remove(unit.Id);

            await ETTask.CompletedTask;
        }
    }
}