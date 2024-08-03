using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;

namespace ET.Client
{
    [AIHandler(AIType.AIType_AutoTask)]
    [FriendOfAttribute(typeof(ET.Client.ClientTaskComponent))]
    public class AI_AutoTask : AAIHandler
    {
        public override int Check(AIComponent aiComponent, int aiConfigId, int nodeConfigId)
        {
            Scene sceneClient = aiComponent.Scene().CurrentScene();
            Unit unit = UnitHelper.GetMyUnitFromCurrentScene(sceneClient);

            if (unit == null)
            {
                return 1;
            }

            if (unit.Type() != UnitType.UnitType_Player)
            {
                return 1;
            }

            ClientTaskComponent taskComponent = unit.GetComponent<ClientTaskComponent>();
            if (taskComponent == null)
            {
                return 1;
            }

            if (taskComponent.AcceptedTasks.Count < 1)
            {
                return 1;
            }

            return 0;
        }

        public override async ETTask Execute(AIComponent aiComponent, int aiConfigId, int nodeConfigId, ETCancellationToken cancellationToken)
        {
            Scene sceneClient = aiComponent.Scene().CurrentScene();
            Unit unit = UnitHelper.GetMyUnitFromCurrentScene(sceneClient);

            int taskConfigId = unit.GetComponent<ClientTaskComponent>().AcceptedTasks.FirstOrDefault();
            TaskConfig config = TaskConfigCategory.Instance.Get(taskConfigId);

            while (config != null)
            {
                SceneNpcConfig sceneNpcConfig = SceneNpcConfigCategory.Instance.Get(config.CompleteNpcConfig);
                if (sceneNpcConfig == null)
                {
                    return;
                }

                float3 target = new(sceneNpcConfig.Position.X, sceneNpcConfig.Position.Y, sceneNpcConfig.Position.Z);
                await unit.MoveToAsync(target, cancellationToken);
                if (cancellationToken.IsCancel())
                {
                    return;
                }

                C2M_CompleteTask message = C2M_CompleteTask.Create();
                message.TaskId = taskConfigId;
                M2C_CompleteTask response = (M2C_CompleteTask)await aiComponent.Root().GetComponent<ClientSenderComponent>().Call(message);
                if (response.Error != ErrorCode.ERR_Success)
                {
                    Log.Error($"交付任务失败");
                    return;
                }

                config = TaskConfigCategory.Instance.Get(unit.GetComponent<ClientTaskComponent>().AcceptedTasks.FirstOrDefault());
            }
        }
    }
}