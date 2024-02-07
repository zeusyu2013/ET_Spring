using System.Collections.Generic;

namespace ET.Server
{
    [FriendOf(typeof (AccountInfo))]
    [EntitySystemOf(typeof (AccountComponent))]
    public static partial class AccountComponentSystem
    {
        [EntitySystem]
        private static void Awake(this AccountComponent self)
        {
        }

        public static async ETTask<(int, long)> CheckAccount(this AccountComponent self, string account, string password, string platform)
        {
            if (string.IsNullOrEmpty(account) || string.IsNullOrEmpty(password))
            {
                return (ErrorCode.ERR_AccountOrPasswordEmpty, -1);
            }

            using (await self.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.Login, account.GetLongHashCode()))
            {
                DBComponent dbComponent = self.Root().GetComponent<DBManagerComponent>().GetZoneDB(self.Zone());
                List<AccountInfo> accountInfos = await dbComponent.Query<AccountInfo>(x => x.Account == account);

                AccountInfo accountInfo = null;
                // 没有找到账号，注册一个
                if (accountInfos.Count < 1)
                {
                    accountInfo = self.AddChild<AccountInfo>();
                    accountInfo.AccountId = accountInfo.Id;
                    accountInfo.Account = account;
                    accountInfo.Password = password;
                    accountInfo.OpenId = "";
                    accountInfo.Platform = platform;
                    accountInfo.CreatedTime = TimeInfo.Instance.ToDateTime(TimeInfo.Instance.ServerNow());
                    accountInfo.LoginTime = TimeInfo.Instance.ToDateTime(TimeInfo.Instance.ServerNow());
                    await dbComponent.Save(accountInfo);
                }
                // 找到账号，对比密码
                else
                {
                    accountInfo = accountInfos[0];
                    if (accountInfo.Password != password)
                    {
                        return (ErrorCode.ERR_PasswordNotMatch, -1);
                    }

                    // 更新登录时间
                    accountInfo.LoginTime = TimeInfo.Instance.ToDateTime(TimeInfo.Instance.ServerNow());
                }

                return (ErrorCode.ERR_Success, accountInfo.AccountId);
            }
        }

        public static async ETTask<(int, long)> CheckOpenId(this AccountComponent self, string openId, string signture, string time, string platform)
        {
            if (string.IsNullOrEmpty(openId))
            {
                return (ErrorCode.ERR_OpenIdEmpty, -1);
            }

            if (string.IsNullOrEmpty(signture))
            {
                return (ErrorCode.ERR_SigntureEmpty, -1);
            }

            string retVal = MD5Helper.SigntureMD5($"{openId},{time},{platform}");
            if (retVal != signture)
            {
                return (ErrorCode.ERR_SigntureNotMatch, -1);
            }

            using (await self.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.Login, openId.GetLongHashCode()))
            {
                DBComponent dbComponent = self.Root().GetComponent<DBManagerComponent>().GetZoneDB(self.Zone());
                List<AccountInfo> accountInfos = await dbComponent.Query<AccountInfo>(x => x.OpenId == openId);

                AccountInfo accountInfo = null;
                // 没有找到账号，注册一个
                if (accountInfos.Count < 1)
                {
                    accountInfo = self.AddChild<AccountInfo>();
                    accountInfo.AccountId = accountInfo.Id;
                    accountInfo.Account = $"ujoy_{openId}";
                    accountInfo.Password = "";
                    accountInfo.OpenId = openId;
                    accountInfo.Platform = platform;
                    accountInfo.CreatedTime = TimeInfo.Instance.ToDateTime(TimeInfo.Instance.ServerNow());
                    accountInfo.LoginTime = TimeInfo.Instance.ToDateTime(TimeInfo.Instance.ServerNow());
                    await dbComponent.Save(accountInfo);
                }
                // 找到账号，更新登录时间
                else
                {
                    accountInfo = accountInfos[0];
                    accountInfo.LoginTime = TimeInfo.Instance.ToDateTime(TimeInfo.Instance.ServerNow());
                }

                return (ErrorCode.ERR_Success, accountInfo.AccountId);
            }
        }
    }
}