using System;

namespace ET.Server
{
    [ChildOf]
    public class WanxinOrder : Entity, IAwake
    {
        public string OrderId;
        public string UnitId;
        public string ServerId;
        public string UserId;
        public string ProductId;
        public DateTime Time;
    }
}