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
    [Message(OuterMessage.C2M_SoulLevelBreak)]
    [ResponseType(nameof(M2C_SoulLevelBreak))]
    public partial class C2M_SoulLevelBreak : MessageObject, ILocationRequest
    {
        public static C2M_SoulLevelBreak Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_SoulLevelBreak), isFromPool) as C2M_SoulLevelBreak;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int SoulConfigId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.SoulConfigId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_SoulLevelBreak)]
    public partial class M2C_SoulLevelBreak : MessageObject, ILocationResponse
    {
        public static M2C_SoulLevelBreak Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_SoulLevelBreak), isFromPool) as M2C_SoulLevelBreak;
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

    [MemoryPackable]
    [Message(OuterMessage.C2M_SoulChooseTalent)]
    [ResponseType(nameof(M2C_SoulChooseTalent))]
    public partial class C2M_SoulChooseTalent : MessageObject, ILocationRequest
    {
        public static C2M_SoulChooseTalent Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_SoulChooseTalent), isFromPool) as C2M_SoulChooseTalent;
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
    [Message(OuterMessage.M2C_SoulChooseTalent)]
    public partial class M2C_SoulChooseTalent : MessageObject, ILocationResponse
    {
        public static M2C_SoulChooseTalent Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_SoulChooseTalent), isFromPool) as M2C_SoulChooseTalent;
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
    [Message(OuterMessage.C2M_GetSoulOnBattle)]
    [ResponseType(nameof(M2C_GetSoulOnBattle))]
    public partial class C2M_GetSoulOnBattle : MessageObject, ILocationRequest
    {
        public static C2M_GetSoulOnBattle Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_GetSoulOnBattle), isFromPool) as C2M_GetSoulOnBattle;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_GetSoulOnBattle)]
    public partial class M2C_GetSoulOnBattle : MessageObject, ILocationResponse
    {
        public static M2C_GetSoulOnBattle Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_GetSoulOnBattle), isFromPool) as M2C_GetSoulOnBattle;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MongoDB.Bson.Serialization.Attributes.BsonDictionaryOptions(MongoDB.Bson.Serialization.Options.DictionaryRepresentation.ArrayOfArrays)]
        [MemoryPackOrder(3)]
        public Dictionary<int, int> Battles { get; set; } = new();
        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.Battles.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_SoulOnBattle)]
    [ResponseType(nameof(M2C_SoulOnBattle))]
    public partial class C2M_SoulOnBattle : MessageObject, ILocationRequest
    {
        public static C2M_SoulOnBattle Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_SoulOnBattle), isFromPool) as C2M_SoulOnBattle;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int SoulConfigId { get; set; }

        [MemoryPackOrder(2)]
        public int Position { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.SoulConfigId = default;
            this.Position = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_SoulOnBattle)]
    public partial class M2C_SoulOnBattle : MessageObject, ILocationResponse
    {
        public static M2C_SoulOnBattle Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_SoulOnBattle), isFromPool) as M2C_SoulOnBattle;
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
        public const ushort C2M_SoulLevelBreak = 14005;
        public const ushort M2C_SoulLevelBreak = 14006;
        public const ushort C2M_SoulUpstar = 14007;
        public const ushort M2C_SoulUpstar = 14008;
        public const ushort C2M_SoulChooseTalent = 14009;
        public const ushort M2C_SoulChooseTalent = 14010;
        public const ushort C2M_GetSoulOnBattle = 14011;
        public const ushort M2C_GetSoulOnBattle = 14012;
        public const ushort C2M_SoulOnBattle = 14013;
        public const ushort M2C_SoulOnBattle = 14014;
    }
}