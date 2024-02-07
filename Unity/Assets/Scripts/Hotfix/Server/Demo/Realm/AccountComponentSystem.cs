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

        public static async ETTask<int> CheckAccount(this AccountComponent self, string account, string password, string platform)
        {
            if (string.IsNullOrEmpty(account) || string.IsNullOrEmpty(password))
            {
                return ErrorCode.ERR_AccountOrPasswordEmpty;
            }

            DBComponent dbComponent = self.Root().GetComponent<DBManagerComponent>().GetZoneDB(self.Zone());
            List<AccountInfo> accountInfos = await dbComponent.Query<AccountInfo>(x => x.Account == account);

            AccountInfo accountInfo = null;
            // 没有找到账号，注册一个
            if (accountInfos.Count < 1)
            {
                accountInfo = self.AddChild<AccountInfo>();
                accountInfo.AccountId = accountInfo.InstanceId;
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
                    return ErrorCode.ERR_PasswordNotMatch;
                }
            }

            return ErrorCode.ERR_Success;
        }
    }
}