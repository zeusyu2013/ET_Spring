namespace ET.Server
{
    [Invoke((long)SceneType.TimeEvent)]
    public class FiberInit_TimeEvent : AInvokeHandler<FiberInit, ETTask>
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

            root.AddComponent<TimeEventComponent>();
            
            await ETTask.CompletedTask;
        }
    }
}