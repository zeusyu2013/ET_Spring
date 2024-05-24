namespace ET.Client
{
    public class AI_Stand : AAIHandler
    {
        public override int Check(AIComponent aiComponent, AIConfig aiConfig)
        {
            long sec = TimeInfo.Instance.ClientNow() / 1000 % 15;
            if (sec >= 10)
            {
                return 0;
            }

            return 1;
        }

        public override ETTask Execute(AIComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}