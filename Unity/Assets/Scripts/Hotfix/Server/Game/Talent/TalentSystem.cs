namespace ET.Server
{
    [FriendOf(typeof(Talent))]
    [EntitySystemOf(typeof(Talent))]
    public static partial class TalentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.Talent self, int configId)
        {
            self.ConfigId = configId;
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.Talent self)
        {
        }

        public static TalentInfo ToMessage(this Talent self)
        {
            TalentInfo info = TalentInfo.Create();
            info.ConfigId = self.ConfigId;
            info.Level = self.Level;
            return info;
        }
    }
}