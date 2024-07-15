using Unity.Mathematics;

namespace ET.Server
{
    [EntitySystemOf(typeof(LocationComponent))]
    [FriendOfAttribute(typeof(ET.Server.LocationComponent))]
    public static partial class LocationComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.LocationComponent self)
        {
            self.SceneName = "";
            self.Position = float3.zero;
            self.Rotation = quaternion.identity;
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.LocationComponent self)
        {
            self.SceneName = "";
            self.Position = float3.zero;
            self.Rotation = quaternion.identity;
        }
    }
}