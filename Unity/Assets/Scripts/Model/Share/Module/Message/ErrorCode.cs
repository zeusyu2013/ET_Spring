namespace ET
{
    public static partial class ErrorCode
    {
        public const int ERR_Success = 0;

        // 1-11004 是SocketError请看SocketError定义
        //-----------------------------------
        // 100000-109999是Core层的错误
        
        // 110000以下的错误请看ErrorCore.cs
        
        // 这里配置逻辑层的错误码
        // 110000 - 200000是抛异常的错误
        // 200001以上不抛异常

        public const int ERR_AccountOrPasswordEmpty = 200002;
        public const int ERR_PasswordNotMatch = 200003;
        public const int ERR_OpenIdEmpty = 200004;
        public const int ERR_SigntureEmpty = 200005;
        public const int ERR_SigntureNotMatch = 200006;
        
        public const int ERR_PlayerIdEmpty = 200007;
        public const int ERR_CreateRoleNameEmpty = 200008;
        public const int ERR_CreateRoleNameSame = 200009;
        public const int ERR_DeleteRoleHasNoRole = 200010;
        
        // DBCache
        public const int ERR_DBCacheUnitIdInvalid = 200020;
        public const int ERR_DBCacheUnitNotFound = 200021;

        public const int ERR_MailIdInvalid = 200030;
        public const int ERR_MailIdNotFound = 200031;

        public const int ERR_SigninedToday = 200040;
    }
}