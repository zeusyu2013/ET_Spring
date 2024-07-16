using MemoryPack;
using System.Collections.Generic;

namespace ET
{
    [MemoryPackable]
    [Message(OuterMessage.TDUserSet)]
    public partial class TDUserSet : MessageObject, IMessage
    {
        public static TDUserSet Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(TDUserSet), isFromPool) as TDUserSet;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public string AccountId { get; set; }

        [MemoryPackOrder(2)]
        public string Properties { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.AccountId = default;
            this.Properties = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.TDUserSetOnce)]
    public partial class TDUserSetOnce : MessageObject, IMessage
    {
        public static TDUserSetOnce Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(TDUserSetOnce), isFromPool) as TDUserSetOnce;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public string AccountId { get; set; }

        [MemoryPackOrder(2)]
        public string Properties { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.AccountId = default;
            this.Properties = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.TDUserAdd)]
    public partial class TDUserAdd : MessageObject, IMessage
    {
        public static TDUserAdd Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(TDUserAdd), isFromPool) as TDUserAdd;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public string AccountId { get; set; }

        [MemoryPackOrder(2)]
        public string Properties { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.AccountId = default;
            this.Properties = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.TDTrack)]
    public partial class TDTrack : MessageObject, IMessage
    {
        public static TDTrack Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(TDTrack), isFromPool) as TDTrack;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public string AccountId { get; set; }

        [MemoryPackOrder(2)]
        public string EventName { get; set; }

        [MemoryPackOrder(3)]
        public string Properties { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.AccountId = default;
            this.EventName = default;
            this.Properties = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.WanxinPayRequest)]
    public partial class WanxinPayRequest : MessageObject
    {
        public static WanxinPayRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(WanxinPayRequest), isFromPool) as WanxinPayRequest;
        }

        [MemoryPackOrder(0)]
        public string app_order_id { get; set; }

        [MemoryPackOrder(1)]
        public string app_role_id { get; set; }

        [MemoryPackOrder(2)]
        public string is_sandbox { get; set; }

        [MemoryPackOrder(3)]
        public string channel { get; set; }

        [MemoryPackOrder(4)]
        public string xx_game_id { get; set; }

        [MemoryPackOrder(5)]
        public string product_id { get; set; }

        [MemoryPackOrder(6)]
        public string order_id { get; set; }

        [MemoryPackOrder(7)]
        public string server_id { get; set; }

        [MemoryPackOrder(8)]
        public string total_fee { get; set; }

        [MemoryPackOrder(9)]
        public string sign { get; set; }

        [MemoryPackOrder(10)]
        public string user_id { get; set; }

        [MemoryPackOrder(11)]
        public string time { get; set; }

        [MemoryPackOrder(12)]
        public string tp { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.app_order_id = default;
            this.app_role_id = default;
            this.is_sandbox = default;
            this.channel = default;
            this.xx_game_id = default;
            this.product_id = default;
            this.order_id = default;
            this.server_id = default;
            this.total_fee = default;
            this.sign = default;
            this.user_id = default;
            this.time = default;
            this.tp = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.WanxinPayResponse)]
    public partial class WanxinPayResponse : MessageObject
    {
        public static WanxinPayResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(WanxinPayResponse), isFromPool) as WanxinPayResponse;
        }

        [MemoryPackOrder(0)]
        public int Ret { get; set; }

        [MemoryPackOrder(1)]
        public string Message { get; set; }

        [MemoryPackOrder(2)]
        public List<string> Content { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Ret = default;
            this.Message = default;
            this.Content.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    public static partial class OuterMessage
    {
        public const ushort TDUserSet = 12002;
        public const ushort TDUserSetOnce = 12003;
        public const ushort TDUserAdd = 12004;
        public const ushort TDTrack = 12005;
        public const ushort WanxinPayRequest = 12006;
        public const ushort WanxinPayResponse = 12007;
    }
}