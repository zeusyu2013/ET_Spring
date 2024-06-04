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
            root.AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.UnOrderedMessage);
            root.AddComponent<DBManagerComponent>();
            root.AddComponent<DBCacheComponent>();
            root.AddComponent<MessageLocationSenderComponent>();
            root.AddComponent<UnitComponent>();
            root.AddComponent<UnitCacheEventComponent>();

            // todo:还没想好怎么做，到时候再说吧。。
            //root.AddComponent<DBVersion, int, int>(root.Fiber.Process, root.Fiber.Zone);

            await ETTask.CompletedTask;
        }
    }
}