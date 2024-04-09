using MemoryPack;
using System.Collections.Generic;

namespace ET
{
    [MemoryPackable]
    [Message(OuterMessage.C2M_GMCommand)]
    public partial class C2M_GMCommand : MessageObject, ILocationMessage
    {
        public static C2M_GMCommand Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_GMCommand), isFromPool) as C2M_GMCommand;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public string GmCommand { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.GmCommand = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_Signin)]
    [ResponseType(nameof(M2C_Signin))]
    public partial class C2M_Signin : MessageObject, ILocationRequest
    {
        public static C2M_Signin Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_Signin), isFromPool) as C2M_Signin;
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
    [Message(OuterMessage.M2C_Signin)]
    public partial class M2C_Signin : MessageObject, ILocationResponse
    {
        public static M2C_Signin Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_Signin), isFromPool) as M2C_Signin;
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
        public const ushort C2M_GMCommand = 20002;
        public const ushort C2M_Signin = 20003;
        public const ushort M2C_Signin = 20004;
    }
}