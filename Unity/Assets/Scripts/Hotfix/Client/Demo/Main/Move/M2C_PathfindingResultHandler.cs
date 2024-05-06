using System;
using Unity.Mathematics;

namespace ET.Client
{
    [MessageHandler(SceneType.MainClient)]
    [FriendOfAttribute(typeof (ET.MoveComponent))]
    public class M2C_PathfindingResultHandler: MessageHandler<Scene, M2C_PathfindingResult>
    {
        protected override async ETTask Run(Scene root, M2C_PathfindingResult message)
        {
            Unit unit = root.CurrentScene().GetComponent<UnitComponent>().Get(message.Id);
            if (unit == null)
            {
                return;
            }

            float speed = unit.GetComponent<NumericComponent>().GetAsFloat(GamePropertyType.GamePropertyType_Speed);

            if (!unit.IsMyUnit())
            {
                unit.GetComponent<MoveComponent>().StopForce();

                using (ListComponent<float3> list = ListComponent<float3>.Create())
                {
                    list.Add(unit.Position);
                    foreach (float3 messagePoint in message.Points)
                    {
                        list.Add(messagePoint);
                    }

                    unit.GetComponent<MoveComponent>().MoveToAsync(list, speed).Coroutine();
                }

                return;
            }

            long moveTime = TimeInfo.Instance.ServerNow() - unit.GetComponent<MoveComponent>().BeginTime;
            long needTime = 0;
            long totalTime = 0;
            int N = 0;
            float3 prePos = message.Points[0];
            for (int i = 1; i < message.Points.Count; ++i)
            {
                float3 nextPos = message.Points[i];

                float3 v = nextPos - prePos;
                float distance = magnitude(v);
                prePos = nextPos;
                needTime = (long)(distance / speed * 1000);

                totalTime += needTime;
                ++N;
                if (totalTime >= moveTime)
                {
                    ++N;
                    break;
                }
            }

            if (totalTime <= moveTime)
            {
                return;
            }

            using (ListComponent<float3> list = ListComponent<float3>.Create())
            {
                list.Add(unit.Position);
                list.AddRange(message.Points);

                if (list.Count < 1)
                {
                    list.Clear();
                    return;
                }

                unit.GetComponent<MoveComponent>().MoveToAsync(list, speed).Coroutine();
            }

            await ETTask.CompletedTask;
        }

        private float magnitude(float3 value)
        {
            return (float) Math.Sqrt((double) value.x * value.x + (double) value.y * value.y + (double) value.z * value.z);
        }
    }
}