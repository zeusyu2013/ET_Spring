namespace ET.Server
{
    [AIHandler(AIType.AIType_Patrol)]
    [FriendOfAttribute(typeof(ET.Server.PatrolComponent))]
    public class AI_Patrol : AAIHandler
    {
        public override int Check(AIComponent aiComponent, int aiConfig, int nodeId)
        {
            Unit unit = aiComponent.GetParent<Unit>();

            return 0;
        }

        public override async ETTask Execute(AIComponent aiComponent, int aiConfig, int nodeId, ETCancellationToken cancellationToken)
        {
            Unit unit = aiComponent.GetParent<Unit>();
            if (unit == null || unit.IsDisposed)
            {
                return;
            }

            PatrolComponent patrolComponent = unit.GetComponent<PatrolComponent>();
            if (patrolComponent == null)
            {
                return;
            }

            MoveComponent moveComponent = unit.GetComponent<MoveComponent>();
            if (moveComponent == null)
            {
                return;
            }

            float speed = unit.GetFloat(GamePropertyType.GP_Speed);
            if (speed < 0.01f)
            {
                return;
            }

            if (cancellationToken.IsCancel())
            {
                moveComponent.Stop(true);
                return;
            }

            bool ret = await moveComponent.MoveToAsync(patrolComponent.Path, speed);
            if (!ret)
            {
                return;
            }

            AINodeConfig nodeConfig = AINodeConfigCategory.Instance.Get(nodeId);

            AIPatrolParam param = (AIPatrolParam)nodeConfig.AIParams;

            long random = RandomGenerator.RandomNumber(param.StayTimeMin, param.StayTimeMax);
            if (random < 1)
            {
                random = 0;
            }
            
            // 巡逻等待时间
            await unit.Root().GetComponent<TimerComponent>().WaitAsync(random);
        }
    }
}