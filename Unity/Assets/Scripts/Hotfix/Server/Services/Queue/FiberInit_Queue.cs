namespace ET.Server
{
    [Invoke((long)SceneType.QueueHall)]
    public class FiberInit_Queue : AInvokeHandler<FiberInit, ETTask>
    {
        public override async ETTask Handle(FiberInit args)
        {
            Scene root = args.Fiber.Root;
            root.AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.UnOrderedMessage);
            root.AddComponent<TimerComponent>();
            root.AddComponent<CoroutineLockComponent>();
            root.AddComponent<ProcessInnerSender>();
            root.AddComponent<MessageSender>();

            await ETTask.CompletedTask;
        }
    }
}