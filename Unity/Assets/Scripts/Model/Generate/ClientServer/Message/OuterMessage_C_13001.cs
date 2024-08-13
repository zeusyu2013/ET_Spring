using MemoryPack;
using System.Collections.Generic;

namespace ET
{
    [MemoryPackable]
    [Message(OuterMessage.M2C_CastStart)]
    public partial class M2C_CastStart : MessageObject, IMessage
    {
        public static M2C_CastStart Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_CastStart), isFromPool) as M2C_CastStart;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long CasterId { get; set; }

        [MemoryPackOrder(2)]
        public int CastConfigId { get; set; }

        [MemoryPackOrder(3)]
        public long CastId { get; set; }

        [MemoryPackOrder(4)]
        public List<long> Targets { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.CasterId = default;
            this.CastConfigId = default;
            this.CastId = default;
            this.Targets.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_CastHit)]
    public partial class M2C_CastHit : MessageObject, IMessage
    {
        public static M2C_CastHit Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_CastHit), isFromPool) as M2C_CastHit;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long CasterId { get; set; }

        [MemoryPackOrder(2)]
        public long CastId { get; set; }

        [MemoryPackOrder(3)]
        public List<long> Targets { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.CasterId = default;
            this.CastId = default;
            this.Targets.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_CastFinish)]
    public partial class M2C_CastFinish : MessageObject, IMessage
    {
        public static M2C_CastFinish Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_CastFinish), isFromPool) as M2C_CastFinish;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long CasterId { get; set; }

        [MemoryPackOrder(2)]
        public long CastId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.CasterId = default;
            this.CastId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_CastBreak)]
    public partial class M2C_CastBreak : MessageObject, IMessage
    {
        public static M2C_CastBreak Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_CastBreak), isFromPool) as M2C_CastBreak;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long CasterId { get; set; }

        [MemoryPackOrder(2)]
        public long CastId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.CasterId = default;
            this.CastId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.BuffInfo)]
    public partial class BuffInfo : MessageObject
    {
        public static BuffInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(BuffInfo), isFromPool) as BuffInfo;
        }

        [MemoryPackOrder(0)]
        public long Id { get; set; }

        [MemoryPackOrder(1)]
        public int ConfigId { get; set; }

        [MemoryPackOrder(2)]
        public long CreateTime { get; set; }

        [MemoryPackOrder(3)]
        public long ExpiredTime { get; set; }

        [MemoryPackOrder(4)]
        public List<byte> ExtraData { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Id = default;
            this.ConfigId = default;
            this.CreateTime = default;
            this.ExpiredTime = default;
            this.ExtraData.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_BuffAdd)]
    public partial class M2C_BuffAdd : MessageObject, IMessage
    {
        public static M2C_BuffAdd Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_BuffAdd), isFromPool) as M2C_BuffAdd;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long UnitId { get; set; }

        [MemoryPackOrder(2)]
        public BuffInfo BuffInfo { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.UnitId = default;
            this.BuffInfo = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_BuffRemove)]
    public partial class M2C_BuffRemove : MessageObject, IMessage
    {
        public static M2C_BuffRemove Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_BuffRemove), isFromPool) as M2C_BuffRemove;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long UnitId { get; set; }

        [MemoryPackOrder(2)]
        public long BuffId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.UnitId = default;
            this.BuffId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_BuffTick)]
    public partial class M2C_BuffTick : MessageObject, IMessage
    {
        public static M2C_BuffTick Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_BuffTick), isFromPool) as M2C_BuffTick;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long UnitId { get; set; }

        [MemoryPackOrder(2)]
        public long BuffId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.UnitId = default;
            this.BuffId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_BuffUpdate)]
    public partial class M2C_BuffUpdate : MessageObject, IMessage
    {
        public static M2C_BuffUpdate Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_BuffUpdate), isFromPool) as M2C_BuffUpdate;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long UnitId { get; set; }

        [MemoryPackOrder(2)]
        public BuffInfo BuffInfo { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.UnitId = default;
            this.BuffInfo = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_DamageResult)]
    public partial class M2C_DamageResult : MessageObject, IMessage
    {
        public static M2C_DamageResult Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_DamageResult), isFromPool) as M2C_DamageResult;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long AttackerId { get; set; }

        [MemoryPackOrder(2)]
        public long TargetId { get; set; }

        [MemoryPackOrder(3)]
        public long Damage { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.AttackerId = default;
            this.TargetId = default;
            this.Damage = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_TreatResult)]
    public partial class M2C_TreatResult : MessageObject, IMessage
    {
        public static M2C_TreatResult Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_TreatResult), isFromPool) as M2C_TreatResult;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long CasterId { get; set; }

        [MemoryPackOrder(2)]
        public long TargetId { get; set; }

        [MemoryPackOrder(3)]
        public long TreatValue { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.CasterId = default;
            this.TargetId = default;
            this.TreatValue = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_Cast)]
    [ResponseType(nameof(M2C_Cast))]
    public partial class C2M_Cast : MessageObject, ILocationRequest
    {
        public static C2M_Cast Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_Cast), isFromPool) as C2M_Cast;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int CastConfigId { get; set; }

        [MemoryPackOrder(2)]
        public long TargetId { get; set; }

        [MemoryPackOrder(3)]
        public Unity.Mathematics.float3 Position { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.CastConfigId = default;
            this.TargetId = default;
            this.Position = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_Cast)]
    public partial class M2C_Cast : MessageObject, ILocationResponse
    {
        public static M2C_Cast Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_Cast), isFromPool) as M2C_Cast;
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
    [Message(OuterMessage.M2C_CooldownChange)]
    public partial class M2C_CooldownChange : MessageObject, IMessage
    {
        public static M2C_CooldownChange Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_CooldownChange), isFromPool) as M2C_CooldownChange;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public List<int> CastConfigId { get; set; } = new();

        [MemoryPackOrder(2)]
        public List<long> CooldownCD { get; set; } = new();

        [MemoryPackOrder(3)]
        public List<long> CooldownStartTime { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.CastConfigId.Clear();
            this.CooldownCD.Clear();
            this.CooldownStartTime.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_SetPosition)]
    public partial class M2C_SetPosition : MessageObject, IMessage
    {
        public static M2C_SetPosition Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_SetPosition), isFromPool) as M2C_SetPosition;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long UnitId { get; set; }

        [MemoryPackOrder(2)]
        public Unity.Mathematics.float3 Position { get; set; }

        [MemoryPackOrder(3)]
        public Unity.Mathematics.quaternion Rotation { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.UnitId = default;
            this.Position = default;
            this.Rotation = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_NumericChange)]
    public partial class M2C_NumericChange : MessageObject, IMessage
    {
        public static M2C_NumericChange Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_NumericChange), isFromPool) as M2C_NumericChange;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long UnitId { get; set; }

        [MongoDB.Bson.Serialization.Attributes.BsonDictionaryOptions(MongoDB.Bson.Serialization.Options.DictionaryRepresentation.ArrayOfArrays)]
        [MemoryPackOrder(2)]
        public Dictionary<int, long> KV { get; set; } = new();
        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.UnitId = default;
            this.KV.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    public static partial class OuterMessage
    {
        public const ushort M2C_CastStart = 13002;
        public const ushort M2C_CastHit = 13003;
        public const ushort M2C_CastFinish = 13004;
        public const ushort M2C_CastBreak = 13005;
        public const ushort BuffInfo = 13006;
        public const ushort M2C_BuffAdd = 13007;
        public const ushort M2C_BuffRemove = 13008;
        public const ushort M2C_BuffTick = 13009;
        public const ushort M2C_BuffUpdate = 13010;
        public const ushort M2C_DamageResult = 13011;
        public const ushort M2C_TreatResult = 13012;
        public const ushort C2M_Cast = 13013;
        public const ushort M2C_Cast = 13014;
        public const ushort M2C_CooldownChange = 13015;
        public const ushort M2C_SetPosition = 13016;
        public const ushort M2C_NumericChange = 13017;
    }
}