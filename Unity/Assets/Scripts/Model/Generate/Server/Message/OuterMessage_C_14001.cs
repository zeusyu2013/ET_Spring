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
        public int ConfigId { get; set; }

        [MemoryPackOrder(1)]
        public int Level { get; set; }

        [MemoryPackOrder(2)]
        public int Star { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.ConfigId = default;
            this.Level = default;
            this.Star = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    public static partial class OuterMessage
    {
        public const ushort SoulInfo = 14002;
    }
}