namespace ET
{
    [EntitySystemOf(typeof(Building))]
    [FriendOfAttribute(typeof(ET.Building))]
    public static partial class BuildingSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Building self, int configId)
        {
            self.ConfigId = configId;
        }
    }
}