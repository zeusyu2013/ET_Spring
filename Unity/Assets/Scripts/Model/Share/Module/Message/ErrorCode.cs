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
        public const int ERR_ChooseRoleNameEmpty = 200011;
        public const int ERR_CreateRoleLimit = 200012;
        
        // DBCache
        public const int ERR_DBCacheUnitIdInvalid = 200020;
        public const int ERR_DBCacheUnitNotFound = 200021;

        public const int ERR_MailIdInvalid = 200030;
        public const int ERR_MailIdNotFound = 200031;

        public const int ERR_SigninedToday = 200040;

        public const int ERR_NotFoundComponent = 200050;

        public const int ERR_NotFoundCurrencies = 200060;
        
        // Guild
        public const int ERR_GuildEmpty = 200100;
        public const int ERR_GuildNameSame = 200101;
        public const int ERR_AlreadyHasGuild = 200102;
        public const int ERR_NotFoundGuild = 200103;
        public const int ERR_PlayerNotHasGuild = 200104;
        
        // Equipment
        public const int ERR_NotFoundEquipment = 200201;
        
        // Bag
        public const int ERR_ExtendBagItemConfigError = 200301;
        public const int ERR_ItemNotEnough = 200302;
        
        // Team
        public const int ERR_AlreadyHasTeam = 200401;
        public const int ERR_NotFoundTeam = 200402;
        public const int ERR_TeamMemberFull = 200403;
    }
}