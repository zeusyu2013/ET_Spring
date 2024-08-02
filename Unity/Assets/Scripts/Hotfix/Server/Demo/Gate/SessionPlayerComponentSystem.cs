namespace ET.Server
{
    [EntitySystemOf(typeof(SessionPlayerComponent))]
    [FriendOfAttribute(typeof(ET.Server.GameRoleComponent))]
    public static partial class SessionPlayerComponentSystem
    {
        [EntitySystem]
        private static void Destroy(this SessionPlayerComponent self)
        {
            Scene root = self.Root();
            if (root.IsDisposed)
            {
                return;
            }
            
            // 发送断线消息
            long unitId = self.GetParent<Session>().GetComponent<SessionPlayerComponent>().Player.GetComponent<GateUnitComponent>().UnitId;
            root.GetComponent<MessageLocationSenderComponent>().Get(LocationType.Unit).Send(unitId, G2M_SessionDisconnect.Create());
        }

        [EntitySystem]
        private static void Awake(this SessionPlayerComponent self)
        {

        }
    }
}