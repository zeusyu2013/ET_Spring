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

    public static partial class OuterMessage
    {
        public const ushort TDUserSet = 12002;
        public const ushort TDUserSetOnce = 12003;
        public const ushort TDUserAdd = 12004;
        public const ushort TDTrack = 12005;
    }
}