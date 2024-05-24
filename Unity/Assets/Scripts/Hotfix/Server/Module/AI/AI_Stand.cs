namespace ET
{
    public class AI_Stand : AAIHandler
    {
        public override int Check(AIComponent aiComponent, AIConfig aiConfig)
        {
            return 1;
        }

        public override async ETTask Execute(AIComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken)
        {
            Fiber fiber = aiComponent.Fiber();
            
            // 因为协程可能被中断，任何协程都要传入cancellationToken，判断如果是中断则要返回
            await fiber.Root.GetComponent<TimerComponent>().WaitAsync(1000, cancellationToken);
            
            if (cancellationToken.IsCancel())
            {
                return;
            }
        }
    }
}