namespace ET.Server
{
    [MessageSessionHandler(SceneType.Realm)]
    public class C2R_LoginHandler: MessageSessionHandler<C2R_Login, R2C_Login>
    {
        protected override async ETTask Run(Session session, C2R_Login request, R2C_Login response)
        {
            // 校验账号密码合法性
            AccountComponent accountComponent = session.Fiber().Root.GetComponent<AccountComponent>();
            var (errorCode, accountId) = await accountComponent.CheckAccount(request.Account, request.Password, request.Platform);
            if (errorCode != ErrorCode.ERR_Success)
            {
                response.Error = errorCode;
                return;
            }

            // 随机分配一个Gate
            StartSceneConfig config = RealmGateAddressHelper.GetGate(session.Zone(), request.Account);
            Log.Debug($"gate address: {config}");

            // 向gate请求一个key,客户端可以拿着这个key连接gate
            R2G_GetLoginKey r2GGetLoginKey = R2G_GetLoginKey.Create();
            r2GGetLoginKey.AccountId = accountId;
            G2R_GetLoginKey g2RGetLoginKey =
                    (G2R_GetLoginKey)await session.Fiber().Root.GetComponent<MessageSender>().Call(config.ActorId, r2GGetLoginKey);

            response.Address = config.InnerIPPort.ToString();
            response.Key = g2RGetLoginKey.Key;
            response.GateId = g2RGetLoginKey.GateId;

            CloseSession(session).Coroutine();
        }

        private async ETTask CloseSession(Session session)
        {
            await session.Root().GetComponent<TimerComponent>().WaitAsync(1000);
            session.Dispose();
        }
    }
}