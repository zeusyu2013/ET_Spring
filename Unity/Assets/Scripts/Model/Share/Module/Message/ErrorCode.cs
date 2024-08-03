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
        public const int ERR_BagCapacityMaxLimit = 200303;

        // Team
        public const int ERR_AlreadyHasTeam = 200401;
        public const int ERR_NotFoundTeam = 200402;
        public const int ERR_TeamMemberFull = 200403;

        // Daily Sign
        public const int ERR_DailySignErrorDay = 200501;

        // Dungeon
        public const int ERR_CreateDungeonFailed = 200601;
        public const int ERR_TransferDungeonFailed = 200602;

        // Mount
        public const int ERR_HasMount = 200701;
        public const int ERR_MountConfigError = 200701;

        // Lottery
        public const int ERR_NotFoundLotteryConfig = 200801;
        public const int ERR_BuildingLevelNotMatch = 200802;

        // Currency
        public const int ERR_CurrencyNotEnough = 200901;

        // Battle
        public const int ERR_CasterError = 201001;
        public const int ERR_CastTargetTypeNotMatch = 201002;
        public const int ERR_NotFoundSkillSelectHandler = 201003;
        public const int ERR_SkillConfigNotFound = 201004;
        public const int ERR_SkillConsumeNotEnough = 201005;
        public const int ERR_CastNoTarget = 201006;
        public const int ERR_AlreadyAlive = 201007;
        public const int ERR_AlreadyDead = 201008;
        public const int ERR_CastIsNull = 201009;
        public const int ERR_CastTargetCounterLessThan1 = 201010;
        public const int ERR_CasterIsNull = 201010;
        public const int ERR_Silent = 201011;
        public const int ERR_CastCDing = 201012;
        
        // Task
        public const int ERR_AlreadyAcceptTask = 203001;
        public const int ERR_CantAcceptAgain = 203002;
        public const int ERR_TaskNotAccepted = 203003;
    }
}