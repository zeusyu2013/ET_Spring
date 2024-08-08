using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_JoyStopHandler : MessageLocationHandler<Unit, C2M_JoyStop>
    {
        protected override async ETTask Run(Unit unit, C2M_JoyStop message)
        {
            using (var list = ListComponent<float3>.Create())
            {
                float3 target = message.Position;
                unit.GetComponent<PathfindingComponent>().Find(unit.Position, target, list);

                List<float3> path = list;
                if (path.Count < 2)
                {
                    unit.Stop(0);
                    return;
                }

                M2C_PathfindingResult m2CPathfindingResult = M2C_PathfindingResult.Create();
                m2CPathfindingResult.Id = unit.Id;
                m2CPathfindingResult.Points.AddRange(path);
                MapMessageHelper.Broadcast(unit, m2CPathfindingResult);

                bool ret = await unit.GetComponent<MoveComponent>().MoveToAsync(path, unit.GetFloat(GamePropertyType.GP_Speed));
                unit.Forward = message.Direction;
                unit.Stop(0);
            }

            await ETTask.CompletedTask;
        }
    }
}