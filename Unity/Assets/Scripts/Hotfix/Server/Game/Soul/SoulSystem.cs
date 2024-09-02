namespace ET.Server
{
    [EntitySystemOf(typeof(Soul))]
    [FriendOfAttribute(typeof(ET.Server.Soul))]
    public static partial class SoulSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.Soul self, int configId)
        {
            self.ConfigId = configId;
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.Soul self)
        {
        }

        public static SoulInfo ToMessage(this Soul self)
        {
            SoulInfo info = SoulInfo.Create();
            info.ConfigId = self.ConfigId;
            info.Level = self.Level;
            info.Star = self.Star;

            return info;
        }

        #region 升级

        public static int Uplevel(this Soul self, long exp)
        {
            return ErrorCode.ERR_Success;
        }

        #endregion

        #region 升星

        public static int Upstar(this Soul self)
        {
            return ErrorCode.ERR_Success;
        }

        #endregion
    }
}