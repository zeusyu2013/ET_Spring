using Unity.Mathematics;

namespace ET.Client
{
    [FriendOfAttribute(typeof(ET.Client.AutoSkillComponent))]
    [FriendOfAttribute(typeof(ET.Client.XunLuoPathComponent))]
    [AIHandler(AIType.AIType_AutoSkill)]
    public class AI_AutoSkill : AAIHandler
    {
        public override int Check(AIComponent aiComponent, int aiConfigId, int nodeConfigId)
        {
            Scene clientScene = aiComponent.Scene().CurrentScene();
            Unit robot = UnitHelper.GetMyUnitFromCurrentScene(clientScene);

            if (robot == null)
            {
                return 1;
            }

            AutoSkillComponent autoSkillComponent = robot.GetComponent<AutoSkillComponent>();
            if (autoSkillComponent == null)
            {
                return 1;
            }

            if (TimeInfo.Instance.ServerNow() < autoSkillComponent.NextAttackTime)
            {
                return 1;
            }

            if (FindTarget(robot) == null)
            {
                return 1;
            }

            autoSkillComponent.NextAttackTime = TimeInfo.Instance.ServerNow() + RandomGenerator.RandomNumber(5 * 1000, 10 * 1000);

            return 0;
        }

        public override async ETTask Execute(AIComponent aiComponent, int aiConfigId, int nodeConfigId, ETCancellationToken cancellationToken)
        {
            Scene clientScene = aiComponent.Scene().CurrentScene();

            Unit robot = UnitHelper.GetMyUnitFromCurrentScene(clientScene);
            if (robot == null)
            {
                return;
            }

            int castConfigId = 0;

            Unit target = FindTarget(robot);

            robot.GetComponent<XunLuoPathComponent>().NextMoveTime = TimeInfo.Instance.ServerNow() + RandomGenerator.RandomNumber(5 * 1000, 8 * 1000);

            if (target != null)
            {
                Session session = clientScene.GetComponent<SessionComponent>().Session;
                if (session != null)
                {
                    C2M_Stop stop = C2M_Stop.Create();
                    session.Send(stop);

                    C2M_Cast c2MCast = C2M_Cast.Create();
                    c2MCast.CastConfigId = castConfigId;
                    session.Send(c2MCast);
                }
            }

            await ETTask.CompletedTask;
        }

        private Unit FindTarget(Unit robot, float distance = 5.0f)
        {
            UnitComponent unitComponent = robot.Scene().CurrentScene().GetComponent<UnitComponent>();
            if (unitComponent == null)
            {
                return null;
            }

            foreach (Entity target in unitComponent.Children.Values)
            {
                if (target is not Unit unit)
                {
                    continue;
                }

                if (unit.Type() != UnitType.UnitType_Player)
                {
                    continue;
                }

                if (math.distance(unit.Position, robot.Position) > distance)
                {
                    continue;
                }

                return unit;
            }

            return null;
        }
    }
}