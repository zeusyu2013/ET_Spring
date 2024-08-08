using System;

namespace ET.Server
{
    [MessageSessionHandler(SceneType.Gate)]
    public class C2G_LoginGateHandler: MessageSessionHandler<C2G_LoginGate, G2C_LoginGate>
    {
        protected override async ETTask Run(Session session, C2G_LoginGate request, G2C_LoginGate response)
        {
            Scene root = session.Root();
            long accountId = root.GetComponent<GateSessionKeyComponent>().Get(request.Key);
            if (accountId == -1)
            {
                response.Error = ErrorCore.ERR_ConnectGateKeyError;
                response.Message = "Gate key验证失败!";
                return;
            }

            session.RemoveComponent<SessionAcceptTimeoutComponent>();

            PlayerComponent playerComponent = root.GetComponent<PlayerComponent>();
            Player player = playerComponent.GetByAccount(accountId);
            // 第一次进游戏
            if (player == null)
            {
                player = playerComponent.AddChildWithId<Player>(accountId);
                playerComponent.Add(player);
                PlayerSessionComponent playerSessionComponent = player.AddComponent<PlayerSessionComponent>();
                playerSessionComponent.AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.GateSession);
                await playerSessionComponent.AddLocation(LocationType.GateSession);

                player.AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.UnOrderedMessage);
                await player.AddLocation(LocationType.Player);

                session.AddComponent<SessionPlayerComponent>().Player = player;
                playerSessionComponent.Session = session;
            }
            else
            {
                // 可能是短线重连，也可能是顶号
                session.AddComponent<SessionPlayerComponent>().Player = player;
                PlayerSessionComponent playerSessionComponent = player.GetComponent<PlayerSessionComponent>();
                if (playerSessionComponent.Session != null)
                {
                    playerSessionComponent.Session.Dispose();
                }
                
                playerSessionComponent.Session = session;

                GateUnitComponent gateUnitComponent = player.GetComponent<GateUnitComponent>();
                if (gateUnitComponent != null)
                {
                    response.UnitId = gateUnitComponent.UnitId;
                }
            }

            session.AddComponentWithId<GameRoleComponent>(player.Id);

            response.PlayerId = player.Id;
            await ETTask.CompletedTask;
        }
    }
}