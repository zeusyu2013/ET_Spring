namespace ET.Server
{
    [EntitySystemOf(typeof(Friend))]
    [FriendOfAttribute(typeof(ET.Server.Friend))]
    public static partial class FriendSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.Friend self)
        {

        }

        public static FriendInfo ToMessage(this Friend self)
        {
            FriendInfo info = FriendInfo.Create();
            info.UnitId = self.UnitId;
            info.UnitName = self.UnitName;
            
            return info;
        }
    }
}