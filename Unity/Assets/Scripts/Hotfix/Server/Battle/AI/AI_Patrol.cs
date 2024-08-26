namespace ET.Server
{
    [AIHandler(AIType.AIType_Patrol)]
    public class AI_Patrol : AAIHandler
    {
        public override int Check(AIComponent aiComponent, int aiConfig, int nodeId)
        {
            throw new System.NotImplementedException();
        }

        public override ETTask Execute(AIComponent aiComponent, int aiConfig, int nodeId, ETCancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}