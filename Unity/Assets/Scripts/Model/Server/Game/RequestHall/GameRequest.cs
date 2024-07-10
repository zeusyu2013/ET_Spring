﻿namespace ET.Server
{
    public enum GameRequestType
    {
        RequestNone,
        RequestAddFriend,
    }

    [ChildOf]
    public class GameRequest : Entity, IAwake, ISerializeToEntity
    {
        public long UnitId;
        public long SenderUnitId;
        public GameRequestType RequestType;
    }
}