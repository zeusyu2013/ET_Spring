namespace ET.Server
{
    [Invoke((long)SceneType.DBCache)]
    public class FiberInit_DBCache : AInvokeHandler<FiberInit, ETTask>
    {
        public override async ETTask Handle(FiberInit fiberInit)
        {
            Scene root = fiberInit.Fiber.Root;
            root.AddComponent<TimerComponent>();
            root.AddComponent<CoroutineLockComponent>();
            root.AddComponent<ProcessInnerSender>();
            root.AddComponent<MessageSender>();
            root.AddComponent<DBManagerComponent>();
            root.AddComponent<DBCacheComponent>();
            root.AddComponent<MessageLocationSenderComponent>();

            await ETTask.CompletedTask;
        }
    }
}