namespace ET.Server
{
    [AIHandler(AIType.AIType_Patrol)]
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
            
            await ETTask.CompletedTask;
        }
    }
}