namespace ET.Server
{
    [Invoke((long)SceneType.TeamHall)]
    public class FiberInit_TeamHall : AInvokeHandler<FiberInit, ETTask>
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
            root.AddComponent<TeamHallComponent>();
            
            await ETTask.CompletedTask;
        }
    }
}