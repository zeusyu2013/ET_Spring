using Unity.Mathematics;

namespace ET.Client
{
    [Event(SceneType.Current)]
    public class MoveDelta_CharacterControllerMove: AEvent<Scene, MoveDelta>
    {
        protected override async ETTask Run(Scene scene, MoveDelta delta)
        {
            Unit unit = delta.Unit;
            float3 target = unit.Position + new float3(delta.X, 0, delta.Y);
            unit.Position += target;
            
            await ETTask.CompletedTask;
        }
    }
}