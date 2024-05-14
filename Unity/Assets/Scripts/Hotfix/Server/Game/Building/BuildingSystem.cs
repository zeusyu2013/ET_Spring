namespace ET.Server
{
    [EntitySystemOf(typeof(Building))]
    [FriendOfAttribute(typeof(Building))]
    public static partial class BuildingSystem
    {
        [EntitySystem]
        private static void Awake(this Building self, int configId)
        {
            self.ConfigId = configId;
        }

        public static BuildingInfo ToMessage(this Building self)
        {
            BuildingInfo info = BuildingInfo.Create();
            info.ConfigId = self.ConfigId;
            info.Level = self.Level;
            return info;
        }
    }
}