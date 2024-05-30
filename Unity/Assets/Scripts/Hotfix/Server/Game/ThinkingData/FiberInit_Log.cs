namespace ET.Server
{
    [Invoke((long)SceneType.Log)]
    public class FiberInit_Log : AInvokeHandler<FiberInit, ETTask>
    {
        public override async ETTask Handle(FiberInit args)
        {
            Scene root = args.Fiber.Root;
            root.AddComponent<TimerComponent>();
            root.AddComponent<CoroutineLockComponent>();
            root.AddComponent<ProcessInnerSender>();
            root.AddComponent<MessageSender>();
            root.AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.UnOrderedMessage);
            root.AddComponent<MessageLocationSenderComponent>();

            root.AddComponent<ThinkingDataComponent, string>("../TDLog");
            
            await ETTask.CompletedTask;
        }
    }
}