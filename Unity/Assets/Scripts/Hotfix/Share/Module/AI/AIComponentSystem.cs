using System;

namespace ET
{
    [EntitySystemOf(typeof(AIComponent))]
    [FriendOf(typeof(AIComponent))]
    [FriendOf(typeof(AIDispatcherComponent))]
    public static partial class AIComponentSystem
    {
        [Invoke(TimerInvokeType.AITimer)]
        public class AITimer : ATimer<AIComponent>
        {
            protected override void Run(AIComponent self)
            {
                try
                {
                    self.Check();
                }
                catch (Exception e)
                {
                    Log.Error($"move timer error: {self.Id}\n{e}");
                }
            }
        }

        [EntitySystem]
        private static void Awake(this AIComponent self, int aiConfigId)
        {
            self.AIConfigId = aiConfigId;
            self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(1000, TimerInvokeType.AITimer, self);
        }

        [EntitySystem]
        private static void Destroy(this AIComponent self)
        {
            self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
            self.CancellationToken?.Cancel();
            self.CancellationToken = null;
            self.Current = 0;
        }

        private static void Check(this AIComponent self)
        {
            Fiber fiber = self.Fiber();
            if (self.Parent == null)
            {
                fiber.Root.GetComponent<TimerComponent>().Remove(ref self.Timer);
                return;
            }

            AIConfig config = AIConfigCategory.Instance.Get(self.AIConfigId);

            foreach (int nodeId in config.AIInfo)
            {
                AINodeConfig nodeConfig = AINodeConfigCategory.Instance.Get(nodeId);

                AIType type = nodeConfig.Type;
                
                AAIHandler aaiHandler = AIDispatcherComponent.Instance.Get(type);

                if (aaiHandler == null)
                {
                    Log.Error($"not found aihandler: {type}");
                    continue;
                }

                int ret = aaiHandler.Check(self, self.AIConfigId, nodeId);
                if (ret != 0)
                {
                    continue;
                }

                if (self.Current == nodeId)
                {
                    break;
                }

                self.Cancel(); // 取消之前的行为
                ETCancellationToken cancellationToken = new();
                self.CancellationToken = cancellationToken;
                self.Current = nodeId;

                aaiHandler.Execute(self, self.AIConfigId, nodeId, cancellationToken).Coroutine();
                return;
            }
        }

        private static void Cancel(this AIComponent self)
        {
            self.CancellationToken?.Cancel();
            self.Current = 0;
            self.CancellationToken = null;
        }
    }
}