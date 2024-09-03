using MemoryPack;
using System.Collections.Generic;

namespace ET
{
    [MemoryPackable]
    [Message(OuterMessage.SoulInfo)]
    public partial class SoulInfo : MessageObject
    {
        public static SoulInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(SoulInfo), isFromPool) as SoulInfo;
        }

        [MemoryPackOrder(0)]
        public long Id { get; set; }

        [MemoryPackOrder(1)]
        public int ConfigId { get; set; }

        [MemoryPackOrder(2)]
        public int Level { get; set; }

        [MemoryPackOrder(3)]
        public int Star { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Id = default;
            this.ConfigId = default;
            this.Level = default;
            this.Star = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_SoulUplevel)]
    [ResponseType(nameof(M2C_SoulUplevel))]
    public partial class C2M_SoulUplevel : MessageObject, ILocationRequest
    {
        public static C2M_SoulUplevel Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_SoulUplevel), isFromPool) as C2M_SoulUplevel;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long SoulId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.SoulId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_SoulUplevel)]
    public partial class M2C_SoulUplevel : MessageObject, ILocationResponse
    {
        public static M2C_SoulUplevel Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_SoulUplevel), isFromPool) as M2C_SoulUplevel;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_SoulUpstar)]
    [ResponseType(nameof(M2C_SoulUpstar))]
    public partial class C2M_SoulUpstar : MessageObject, ILocationRequest
    {
        public static C2M_SoulUpstar Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_SoulUpstar), isFromPool) as C2M_SoulUpstar;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long SoulId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.SoulId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_SoulUpstar)]
    public partial class M2C_SoulUpstar : MessageObject, ILocationResponse
    {
        public static M2C_SoulUpstar Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_SoulUpstar), isFromPool) as M2C_SoulUpstar;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    public static partial class OuterMessage
    {
        public const ushort SoulInfo = 14002;
        public const ushort C2M_SoulUplevel = 14003;
        public const ushort M2C_SoulUplevel = 14004;
        public const ushort C2M_SoulUpstar = 14005;
        public const ushort M2C_SoulUpstar = 14006;
    }
}