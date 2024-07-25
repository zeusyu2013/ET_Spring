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

    public static partial class OuterMessage
    {
        public const ushort C2M_CastSkill = 13002;
        public const ushort M2C_CastSkill = 13003;
    }
}