using Unity.Mathematics;

namespace ET.Server
{
    [ComponentOf]
    [UnitCacheEvent(typeof(LocationComponent))]
    public class LocationComponent : Entity, IAwake, IDestroy, ITransfer
    {
        public string SceneName;

        public float3 Position;

        public quaternion Rotation;
    }
}