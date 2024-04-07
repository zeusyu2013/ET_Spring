namespace ET.Server
{


[Invoke((long)SceneType.Guild)]
    public class FiberInit_Guild: AInvokeHandler<FiberInit, ETTask>
    {
        public override async ETTask Handle(FiberInit fiberInit)
        {
            Scene root = fiberInit.Fiber.Root;
            root.AddComponent<TimerComponent>();
            root.AddComponent<CoroutineLockComponent>();
            root.AddComponent<ProcessInnerSender>();
            root.AddComponent<MessageSender>();
            root.AddComponent<DBManagerComponent>();

            root.AddComponent<GuildComponent>();
            
            await ETTask.CompletedTask;
        }
    }
}