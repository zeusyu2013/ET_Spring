namespace ET.Server
{
    [EntitySystemOf(typeof(GameRequest))]
    [FriendOfAttribute(typeof(ET.Server.GameRequest))]
    public static partial class GameRequestSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.GameRequest self)
        {
        }

        public static GameRequestInfo ToMessage(this GameRequest self)
        {
            GameRequestInfo info = GameRequestInfo.Create();
            info.UnitId = self.UnitId;
            info.SenderUnitId = self.SenderUnitId;
            info.RequestType = (int)self.RequestType;

            return info;
        }
    }
}