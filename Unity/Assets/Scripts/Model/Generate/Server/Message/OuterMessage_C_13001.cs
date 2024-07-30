using MemoryPack;
using System.Collections.Generic;

namespace ET
{
    [MemoryPackable]
    [Message(OuterMessage.C2M_CastSkill)]
    [ResponseType(nameof(M2C_CastSkill))]
    public partial class C2M_CastSkill : MessageObject, ILocationRequest
    {
        public static C2M_CastSkill Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_CastSkill), isFromPool) as C2M_CastSkill;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int SkillConfigId { get; set; }

        [MemoryPackOrder(2)]
        public int SkillLevel { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.SkillConfigId = default;
            this.SkillLevel = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_CastSkill)]
    public partial class M2C_CastSkill : MessageObject, ILocationResponse
    {
        public static M2C_CastSkill Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_CastSkill), isFromPool) as M2C_CastSkill;
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
    [Message(OuterMessage.M2C_CastStart)]
    public partial class M2C_CastStart : MessageObject, ILocationMessage
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
    public partial class M2C_CastHit : MessageObject, ILocationMessage
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
    public partial class M2C_CastFinish : MessageObject, ILocationMessage
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
    public partial class M2C_CastBreak : MessageObject, ILocationMessage
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
    public partial class M2C_BuffAdd : MessageObject, ILocationMessage
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
    public partial class M2C_BuffRemove : MessageObject, ILocationMessage
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
    public partial class M2C_BuffTick : MessageObject, ILocationMessage
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
    public partial class M2C_BuffUpdate : MessageObject, ILocationMessage
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
    [Message(OuterMessage.M2C_BattleResult)]
    public partial class M2C_BattleResult : MessageObject, ILocationMessage
    {
        public static M2C_BattleResult Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_BattleResult), isFromPool) as M2C_BattleResult;
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

    public static partial class OuterMessage
    {
        public const ushort C2M_CastSkill = 13002;
        public const ushort M2C_CastSkill = 13003;
        public const ushort M2C_CastStart = 13004;
        public const ushort M2C_CastHit = 13005;
        public const ushort M2C_CastFinish = 13006;
        public const ushort M2C_CastBreak = 13007;
        public const ushort BuffInfo = 13008;
        public const ushort M2C_BuffAdd = 13009;
        public const ushort M2C_BuffRemove = 13010;
        public const ushort M2C_BuffTick = 13011;
        public const ushort M2C_BuffUpdate = 13012;
        public const ushort M2C_BattleResult = 13013;
    }
}