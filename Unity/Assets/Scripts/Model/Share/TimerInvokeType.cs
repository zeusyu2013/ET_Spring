﻿namespace ET
{
    [UniqueId(100, 10000)]
    public static class TimerInvokeType
    {
        // 框架层100-200，逻辑层的timer type从200起
        public const int WaitTimer = 100;
        public const int SessionIdleChecker = 101;
        public const int MessageLocationSenderChecker = 102;
        public const int MessageSenderChecker = 103;
        
        // 框架层200-300
        public const int MoveTimer = 201;
        public const int AITimer = 202;
        public const int SessionAcceptTimeout = 203;
        public const int DBCacheTimer = 204;
        public const int DBCacheSaveTimer = 205;
        public const int UnitDBSaveTimer = 206;

        // 逻辑层300-
        public const int GameBuffTimer = 300;
        public const int FightScoreRankSortTimer = 301;
        public const int DailyCheckTimer = 302;
        public const int DungeonTimer = 304;

        public const int BuffTimer = 401;
        public const int BuffExpiredTimer = 402;
        public const int BuffTickTimer = 403;

        public const int BulletTickTimer = 404;
        public const int BulletTickTimer2 = 405;
        public const int BulletTickTimer3 = 406;
        public const int BulletTotalTimer = 407;

        public const int TrapTickTimer = 408;
        public const int TrapTotalTimer = 409;

        public const int FxTimer = 410;

        public const int CreateMonsterTimer = 415;
        public const int MonsterDeadTimer = 416;

        public const int HeightSyncTimer = 420;

        public const int DropBagTimer = 421;
        
        public const int BattleSpeedTimer = 422;
        
        public const int ConsumeRecoverTimer = 423;
    }
}