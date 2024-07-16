namespace ET.Server
{
    [Invoke((long)SceneType.PayHall)]
    public class FiberInit_PayHall : AInvokeHandler<FiberInit, ETTask>
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
            root.AddComponent<DBManagerComponent>();

            StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.Get((int)root.Id);
            root.AddComponent<HttpComponent, string>($"http://*:{startSceneConfig.Port}/");
            
            root.AddComponent<PaymentComponent>();
            
            await ETTask.CompletedTask;
        }
    }
}