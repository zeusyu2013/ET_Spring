using System;

namespace ET.Server
{
    [ChildOf(typeof(AccountComponent))]
    public class AccountInfo: Entity, IAwake
    {
        public long AccountId;
        public string Account;
        public string Password;
        public string OpenId;
        public string Platform;
        public DateTime CreatedTime;
        public DateTime LoginTime;
    }
}