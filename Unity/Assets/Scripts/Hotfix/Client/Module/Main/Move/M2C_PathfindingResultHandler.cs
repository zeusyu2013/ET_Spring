using System;
using Unity.Mathematics;

namespace ET.Client
{
    [MessageHandler(SceneType.MainClient)]
    [FriendOfAttribute(typeof(ET.MoveComponent))]
    public class M2C_PathfindingResultHandler : MessageHandler<Scene, M2C_PathfindingResult>
    {
        protected override async ETTask Run(Scene root, M2C_PathfindingResult message)
        {
            Unit unit = root.CurrentScene().GetComponent<UnitComponent>().Get(message.Id);
            if (unit == null)
            {
                return;
            }

            if (message.Points.Count < 1)
            {
                Log.Error($"寻路点太少");
                return;
            }

            float speed = unit.GetComponent<NumericComponent>().GetAsFloat(GamePropertyType.GP_Speed);
            if (speed < 0.01f)
            {
                Log.Error($"移动速度为0");
                return;
            }

            // 如果是当前玩家，以客户端为准
            if (!unit.IsMyUnit())
            {
                unit.GetComponent<MoveComponent>().StopForce();

                using (ListComponent<float3> list = ListComponent<float3>.Create())
                {
                    list.Add(unit.Position);
                    list.AddRange(message.Points);

                    unit.GetComponent<MoveComponent>().MoveToAsync(list, speed).Coroutine();
                }
                
                return;
            }

            long movedTime = TimeInfo.Instance.ServerNow() - unit.GetComponent<MoveComponent>().BeginTime;
            long needTime = 0;
            long totalTime = 0;
            int N = 0;

            float3 prePosition = message.Points[0];
            for (int i = 1; i < message.Points.Count; i++)
            {
                float3 nextPosition = message.Points[i];
                float distance = math.distance(nextPosition, prePosition);
                needTime = (long)(distance / speed * 1000);

                totalTime += needTime;
                N += 1;

                if (totalTime >= movedTime)
                {
                    N += 1;
                    break;
                }
            }

            if (totalTime < movedTime)
            {
                return;
            }

            using (var list = ListComponent<float3>.Create())
            {
                list.Add(unit.Position);

                for (int i = N; i < message.Points.Count; i++)
                {
                    list.Add(message.Points[i]);
                }

                if (list.Count < 2)
                {
                    list.Clear();
                    return;
                }

                unit.GetComponent<MoveComponent>().MoveToAsync(list, speed).Coroutine();
            }

            await ETTask.CompletedTask;
        }
    }
}