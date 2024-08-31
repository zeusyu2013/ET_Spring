namespace ET.Server
{
    [AIHandler(AIType.AIType_Cast)]
    public class AI_Cast : AAIHandler
    {
        public override int Check(AIComponent aiComponent, int aiConfig, int nodeId)
        {
            return 0;
        }

        public override async ETTask Execute(AIComponent aiComponent, int aiConfig, int nodeId, ETCancellationToken cancellationToken)
        {
            AINodeConfig nodeConfig = AINodeConfigCategory.Instance.Get(nodeId);

            AICastParam param = (AICastParam)nodeConfig.AIParams;

            int count = param.CastConfigIds.Count;
            if (count < 1)
            {
                return;
            }
            
            foreach (int castConfigId in param.CastConfigIds)
            {
                if (castConfigId < 1)
                {
                    continue;
                }
                
                
            }
            
            await ETTask.CompletedTask;
        }
    }
}