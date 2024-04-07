﻿namespace ET.Server
{
    [Invoke((long)SceneType.Rank)]
    public class FiberInit_Rank : AInvokeHandler<FiberInit, ETTask>
    {
        public override async ETTask Handle(FiberInit fiberInit)
        {
            Scene root = fiberInit.Fiber.Root;
            root.AddComponent<TimerComponent>();
            root.AddComponent<CoroutineLockComponent>();
            root.AddComponent<ProcessInnerSender>();
            root.AddComponent<MessageSender>();
            root.AddComponent<DBManagerComponent>();

            root.AddComponent<FightScoreRankComponent>();
            
            await ETTask.CompletedTask;
        }
    }
}