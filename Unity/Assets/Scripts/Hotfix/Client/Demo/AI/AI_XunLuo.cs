using Unity.Mathematics;

namespace ET.Client
{
    [AIHandler(AIType.AIType_XunLuo)]
    [FriendOfAttribute(typeof(ET.Client.XunLuoPathComponent))]
    public class AI_XunLuo : AAIHandler
    {
        public override int Check(AIComponent aiComponent, AIConfig aiConfig)
        {
            Scene clientScene = aiComponent.Scene().CurrentScene();
            Unit unit = UnitHelper.GetMyUnitFromCurrentScene(clientScene);

            if (unit == null)
            {
                return 1;
            }

            XunLuoPathComponent xunLuoPathComponent = unit.GetComponent<XunLuoPathComponent>();
            if (TimeInfo.Instance.ServerNow() < xunLuoPathComponent.NextMoveTime)
            {
                return 1;
            }

            if (unit.GetInt(GamePropertyType.GamePropertyType_CantMove) > 0)
            {
                return 1;
            }

            xunLuoPathComponent.NextMoveTime = TimeInfo.Instance.ServerNow() + RandomGenerator.RandomNumber(8 * 1000, 15 * 1000);

            return 0;
        }

        public override async ETTask Execute(AIComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken)
        {
            Scene root = aiComponent.Root();

            Unit myUnit = UnitHelper.GetMyUnitFromClientScene(root);
            if (myUnit == null)
            {
                return;
            }

            Log.Debug("开始巡逻");

            while (true)
            {
                XunLuoPathComponent xunLuoPathComponent = myUnit.GetComponent<XunLuoPathComponent>();
                float3 nextTarget = xunLuoPathComponent.GetCurrent();
                await myUnit.MoveToAsync(nextTarget, cancellationToken);
                if (cancellationToken.IsCancel())
                {
                    return;
                }

                xunLuoPathComponent.MoveNext();
            }
        }
    }
}