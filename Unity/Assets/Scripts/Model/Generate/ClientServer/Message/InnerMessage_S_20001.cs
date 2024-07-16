using MemoryPack;
using System.Collections.Generic;

namespace ET
{
    [MemoryPackable]
    [Message(InnerMessage.ObjectQueryRequest)]
    [ResponseType(nameof(ObjectQueryResponse))]
    public partial class ObjectQueryRequest : MessageObject, IRequest
    {
        public static ObjectQueryRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(ObjectQueryRequest), isFromPool) as ObjectQueryRequest;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long Key { get; set; }

        [MemoryPackOrder(2)]
        public long InstanceId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Key = default;
            this.InstanceId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.M2A_Reload)]
    [ResponseType(nameof(A2M_Reload))]
    public partial class M2A_Reload : MessageObject, IRequest
    {
        public static M2A_Reload Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2A_Reload), isFromPool) as M2A_Reload;
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
    [Message(InnerMessage.A2M_Reload)]
    public partial class A2M_Reload : MessageObject, IResponse
    {
        public static A2M_Reload Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(A2M_Reload), isFromPool) as A2M_Reload;
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
    [Message(InnerMessage.G2G_LockRequest)]
    [ResponseType(nameof(G2G_LockResponse))]
    public partial class G2G_LockRequest : MessageObject, IRequest
    {
        public static G2G_LockRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2G_LockRequest), isFromPool) as G2G_LockRequest;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long Id { get; set; }

        [MemoryPackOrder(2)]
        public string Address { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Id = default;
            this.Address = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.G2G_LockResponse)]
    public partial class G2G_LockResponse : MessageObject, IResponse
    {
        public static G2G_LockResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2G_LockResponse), isFromPool) as G2G_LockResponse;
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
    [Message(InnerMessage.G2G_LockReleaseRequest)]
    [ResponseType(nameof(G2G_LockReleaseResponse))]
    public partial class G2G_LockReleaseRequest : MessageObject, IRequest
    {
        public static G2G_LockReleaseRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2G_LockReleaseRequest), isFromPool) as G2G_LockReleaseRequest;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long Id { get; set; }

        [MemoryPackOrder(2)]
        public string Address { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Id = default;
            this.Address = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.G2G_LockReleaseResponse)]
    public partial class G2G_LockReleaseResponse : MessageObject, IResponse
    {
        public static G2G_LockReleaseResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2G_LockReleaseResponse), isFromPool) as G2G_LockReleaseResponse;
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
    [Message(InnerMessage.ObjectAddRequest)]
    [ResponseType(nameof(ObjectAddResponse))]
    public partial class ObjectAddRequest : MessageObject, IRequest
    {
        public static ObjectAddRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(ObjectAddRequest), isFromPool) as ObjectAddRequest;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Type { get; set; }

        [MemoryPackOrder(2)]
        public long Key { get; set; }

        [MemoryPackOrder(3)]
        public ActorId ActorId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Type = default;
            this.Key = default;
            this.ActorId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.ObjectAddResponse)]
    public partial class ObjectAddResponse : MessageObject, IResponse
    {
        public static ObjectAddResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(ObjectAddResponse), isFromPool) as ObjectAddResponse;
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
    [Message(InnerMessage.ObjectLockRequest)]
    [ResponseType(nameof(ObjectLockResponse))]
    public partial class ObjectLockRequest : MessageObject, IRequest
    {
        public static ObjectLockRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(ObjectLockRequest), isFromPool) as ObjectLockRequest;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Type { get; set; }

        [MemoryPackOrder(2)]
        public long Key { get; set; }

        [MemoryPackOrder(3)]
        public ActorId ActorId { get; set; }

        [MemoryPackOrder(4)]
        public int Time { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Type = default;
            this.Key = default;
            this.ActorId = default;
            this.Time = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.ObjectLockResponse)]
    public partial class ObjectLockResponse : MessageObject, IResponse
    {
        public static ObjectLockResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(ObjectLockResponse), isFromPool) as ObjectLockResponse;
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
    [Message(InnerMessage.ObjectUnLockRequest)]
    [ResponseType(nameof(ObjectUnLockResponse))]
    public partial class ObjectUnLockRequest : MessageObject, IRequest
    {
        public static ObjectUnLockRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(ObjectUnLockRequest), isFromPool) as ObjectUnLockRequest;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Type { get; set; }

        [MemoryPackOrder(2)]
        public long Key { get; set; }

        [MemoryPackOrder(3)]
        public ActorId OldActorId { get; set; }

        [MemoryPackOrder(4)]
        public ActorId NewActorId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Type = default;
            this.Key = default;
            this.OldActorId = default;
            this.NewActorId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.ObjectUnLockResponse)]
    public partial class ObjectUnLockResponse : MessageObject, IResponse
    {
        public static ObjectUnLockResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(ObjectUnLockResponse), isFromPool) as ObjectUnLockResponse;
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
    [Message(InnerMessage.ObjectRemoveRequest)]
    [ResponseType(nameof(ObjectRemoveResponse))]
    public partial class ObjectRemoveRequest : MessageObject, IRequest
    {
        public static ObjectRemoveRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(ObjectRemoveRequest), isFromPool) as ObjectRemoveRequest;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Type { get; set; }

        [MemoryPackOrder(2)]
        public long Key { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Type = default;
            this.Key = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.ObjectRemoveResponse)]
    public partial class ObjectRemoveResponse : MessageObject, IResponse
    {
        public static ObjectRemoveResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(ObjectRemoveResponse), isFromPool) as ObjectRemoveResponse;
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
    [Message(InnerMessage.ObjectGetRequest)]
    [ResponseType(nameof(ObjectGetResponse))]
    public partial class ObjectGetRequest : MessageObject, IRequest
    {
        public static ObjectGetRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(ObjectGetRequest), isFromPool) as ObjectGetRequest;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Type { get; set; }

        [MemoryPackOrder(2)]
        public long Key { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Type = default;
            this.Key = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.ObjectGetResponse)]
    public partial class ObjectGetResponse : MessageObject, IResponse
    {
        public static ObjectGetResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(ObjectGetResponse), isFromPool) as ObjectGetResponse;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public int Type { get; set; }

        [MemoryPackOrder(4)]
        public ActorId ActorId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.Type = default;
            this.ActorId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.R2G_GetLoginKey)]
    [ResponseType(nameof(G2R_GetLoginKey))]
    public partial class R2G_GetLoginKey : MessageObject, IRequest
    {
        public static R2G_GetLoginKey Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(R2G_GetLoginKey), isFromPool) as R2G_GetLoginKey;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long AccountId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.AccountId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.G2R_GetLoginKey)]
    public partial class G2R_GetLoginKey : MessageObject, IResponse
    {
        public static G2R_GetLoginKey Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2R_GetLoginKey), isFromPool) as G2R_GetLoginKey;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public long Key { get; set; }

        [MemoryPackOrder(4)]
        public long GateId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.Key = default;
            this.GateId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.G2M_SessionDisconnect)]
    public partial class G2M_SessionDisconnect : MessageObject, ILocationMessage
    {
        public static G2M_SessionDisconnect Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2M_SessionDisconnect), isFromPool) as G2M_SessionDisconnect;
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
    [Message(InnerMessage.ObjectQueryResponse)]
    public partial class ObjectQueryResponse : MessageObject, IResponse
    {
        public static ObjectQueryResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(ObjectQueryResponse), isFromPool) as ObjectQueryResponse;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public byte[] Entity { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.Entity = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.M2M_UnitTransferRequest)]
    [ResponseType(nameof(M2M_UnitTransferResponse))]
    public partial class M2M_UnitTransferRequest : MessageObject, IRequest
    {
        public static M2M_UnitTransferRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2M_UnitTransferRequest), isFromPool) as M2M_UnitTransferRequest;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public ActorId OldActorId { get; set; }

        [MemoryPackOrder(2)]
        public byte[] Unit { get; set; }

        [MemoryPackOrder(3)]
        public List<byte[]> Entitys { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.OldActorId = default;
            this.Unit = default;
            this.Entitys.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.M2M_UnitTransferResponse)]
    public partial class M2M_UnitTransferResponse : MessageObject, IResponse
    {
        public static M2M_UnitTransferResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2M_UnitTransferResponse), isFromPool) as M2M_UnitTransferResponse;
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
    [Message(InnerMessage.Other2DBCache_AddOrUpdateUnitCache)]
    public partial class Other2DBCache_AddOrUpdateUnitCache : MessageObject, IMessage
    {
        public static Other2DBCache_AddOrUpdateUnitCache Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Other2DBCache_AddOrUpdateUnitCache), isFromPool) as Other2DBCache_AddOrUpdateUnitCache;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long UnitId { get; set; }

        [MemoryPackOrder(2)]
        public List<string> EntityTypes { get; set; } = new();

        [MemoryPackOrder(3)]
        public List<byte[]> EntityBytes { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.UnitId = default;
            this.EntityTypes.Clear();
            this.EntityBytes.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.Other2DBCache_GetEntities)]
    [ResponseType(nameof(DBCache2Other_GetEntities))]
    public partial class Other2DBCache_GetEntities : MessageObject, IRequest
    {
        public static Other2DBCache_GetEntities Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Other2DBCache_GetEntities), isFromPool) as Other2DBCache_GetEntities;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long UnitId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.UnitId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.DBCache2Other_GetEntities)]
    public partial class DBCache2Other_GetEntities : MessageObject, IResponse
    {
        public static DBCache2Other_GetEntities Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(DBCache2Other_GetEntities), isFromPool) as DBCache2Other_GetEntities;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public List<byte[]> EntityBytes { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.EntityBytes.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.Rank_FightScore)]
    public partial class Rank_FightScore : MessageObject
    {
        public static Rank_FightScore Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Rank_FightScore), isFromPool) as Rank_FightScore;
        }

        [MemoryPackOrder(0)]
        public long UnitId { get; set; }

        [MemoryPackOrder(1)]
        public long FightScore { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.UnitId = default;
            this.FightScore = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.Map2Rank_UpdateScore)]
    public partial class Map2Rank_UpdateScore : MessageObject, IMessage
    {
        public static Map2Rank_UpdateScore Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Map2Rank_UpdateScore), isFromPool) as Map2Rank_UpdateScore;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long UnitId { get; set; }

        [MemoryPackOrder(2)]
        public long FightScore { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.UnitId = default;
            this.FightScore = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.M2M_ChatBroadcast)]
    public partial class M2M_ChatBroadcast : MessageObject, IMessage
    {
        public static M2M_ChatBroadcast Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2M_ChatBroadcast), isFromPool) as M2M_ChatBroadcast;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int ChannelId { get; set; }

        [MemoryPackOrder(2)]
        public string Content { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ChannelId = default;
            this.Content = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.GuildInfo)]
    public partial class GuildInfo : MessageObject
    {
        public static GuildInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(GuildInfo), isFromPool) as GuildInfo;
        }

        [MemoryPackOrder(0)]
        public long GuildId { get; set; }

        [MemoryPackOrder(1)]
        public string GuildName { get; set; }

        [MemoryPackOrder(2)]
        public int GuildLevel { get; set; }

        [MemoryPackOrder(3)]
        public int GuildMemberCount { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.GuildId = default;
            this.GuildName = default;
            this.GuildLevel = default;
            this.GuildMemberCount = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.GuildMemberInfo)]
    public partial class GuildMemberInfo : MessageObject
    {
        public static GuildMemberInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(GuildMemberInfo), isFromPool) as GuildMemberInfo;
        }

        [MemoryPackOrder(0)]
        public long UnitId { get; set; }

        [MemoryPackOrder(1)]
        public int GuildMemberType { get; set; }

        [MemoryPackOrder(2)]
        public int OnlineStatus { get; set; }

        [MemoryPackOrder(3)]
        public long OfflineTime { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.UnitId = default;
            this.GuildMemberType = default;
            this.OnlineStatus = default;
            this.OfflineTime = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.M2G_CreateGuild)]
    [ResponseType(nameof(G2M_CreateGuild))]
    public partial class M2G_CreateGuild : MessageObject, IRequest
    {
        public static M2G_CreateGuild Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2G_CreateGuild), isFromPool) as M2G_CreateGuild;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public string GuildName { get; set; }

        [MemoryPackOrder(2)]
        public long UnitId { get; set; }

        [MemoryPackOrder(3)]
        public string UnitName { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.GuildName = default;
            this.UnitId = default;
            this.UnitName = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.G2M_CreateGuild)]
    public partial class G2M_CreateGuild : MessageObject, IResponse
    {
        public static G2M_CreateGuild Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2M_CreateGuild), isFromPool) as G2M_CreateGuild;
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
    [Message(InnerMessage.M2G_GetAllGuilds)]
    [ResponseType(nameof(G2M_GetAllGuilds))]
    public partial class M2G_GetAllGuilds : MessageObject, IRequest
    {
        public static M2G_GetAllGuilds Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2G_GetAllGuilds), isFromPool) as M2G_GetAllGuilds;
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
    [Message(InnerMessage.G2M_GetAllGuilds)]
    public partial class G2M_GetAllGuilds : MessageObject, IResponse
    {
        public static G2M_GetAllGuilds Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2M_GetAllGuilds), isFromPool) as G2M_GetAllGuilds;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public List<GuildInfo> GuildInfos { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.GuildInfos.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.M2G_RequestJoinGuild)]
    [ResponseType(nameof(G2M_RequestJoinGuild))]
    public partial class M2G_RequestJoinGuild : MessageObject, IRequest
    {
        public static M2G_RequestJoinGuild Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2G_RequestJoinGuild), isFromPool) as M2G_RequestJoinGuild;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public string GuildName { get; set; }

        [MemoryPackOrder(2)]
        public long UnitId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.GuildName = default;
            this.UnitId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.G2M_RequestJoinGuild)]
    public partial class G2M_RequestJoinGuild : MessageObject, IResponse
    {
        public static G2M_RequestJoinGuild Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2M_RequestJoinGuild), isFromPool) as G2M_RequestJoinGuild;
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
    [Message(InnerMessage.M2G_RequestQuitGuild)]
    [ResponseType(nameof(G2M_RequestQuitGuild))]
    public partial class M2G_RequestQuitGuild : MessageObject, IRequest
    {
        public static M2G_RequestQuitGuild Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2G_RequestQuitGuild), isFromPool) as M2G_RequestQuitGuild;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public string GuildName { get; set; }

        [MemoryPackOrder(2)]
        public long UnitId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.GuildName = default;
            this.UnitId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.G2M_RequestQuitGuild)]
    public partial class G2M_RequestQuitGuild : MessageObject, IResponse
    {
        public static G2M_RequestQuitGuild Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2M_RequestQuitGuild), isFromPool) as G2M_RequestQuitGuild;
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
    [Message(InnerMessage.NewDayNotify)]
    public partial class NewDayNotify : MessageObject, IMessage
    {
        public static NewDayNotify Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(NewDayNotify), isFromPool) as NewDayNotify;
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
    [Message(InnerMessage.DailyNotify)]
    public partial class DailyNotify : MessageObject, IMessage
    {
        public static DailyNotify Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(DailyNotify), isFromPool) as DailyNotify;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int DailyConfig { get; set; }

        [MemoryPackOrder(2)]
        public bool OpenOrClose { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.DailyConfig = default;
            this.OpenOrClose = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.GameRequestInfo)]
    public partial class GameRequestInfo : MessageObject
    {
        public static GameRequestInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(GameRequestInfo), isFromPool) as GameRequestInfo;
        }

        [MemoryPackOrder(0)]
        public long UnitId { get; set; }

        [MemoryPackOrder(1)]
        public long SenderUnitId { get; set; }

        [MemoryPackOrder(2)]
        public int RequestType { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.UnitId = default;
            this.SenderUnitId = default;
            this.RequestType = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.Manager2Request_ShutDown)]
    [ResponseType(nameof(Request2Manager_ShutDown))]
    public partial class Manager2Request_ShutDown : MessageObject, IRequest
    {
        public static Manager2Request_ShutDown Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Manager2Request_ShutDown), isFromPool) as Manager2Request_ShutDown;
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
    [Message(InnerMessage.Request2Manager_ShutDown)]
    public partial class Request2Manager_ShutDown : MessageObject, IResponse
    {
        public static Request2Manager_ShutDown Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Request2Manager_ShutDown), isFromPool) as Request2Manager_ShutDown;
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
    [Message(InnerMessage.M2Request_AddRequest)]
    [ResponseType(nameof(Request2M_AddRequest))]
    public partial class M2Request_AddRequest : MessageObject, IRequest
    {
        public static M2Request_AddRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2Request_AddRequest), isFromPool) as M2Request_AddRequest;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long UnitId { get; set; }

        [MemoryPackOrder(2)]
        public long SenderUnitId { get; set; }

        [MemoryPackOrder(3)]
        public int RequestType { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.UnitId = default;
            this.SenderUnitId = default;
            this.RequestType = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.Request2M_AddRequest)]
    public partial class Request2M_AddRequest : MessageObject, IResponse
    {
        public static Request2M_AddRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Request2M_AddRequest), isFromPool) as Request2M_AddRequest;
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
    [Message(InnerMessage.M2Request_GetRequests)]
    [ResponseType(nameof(Request2M_GetRequests))]
    public partial class M2Request_GetRequests : MessageObject, IRequest
    {
        public static M2Request_GetRequests Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2Request_GetRequests), isFromPool) as M2Request_GetRequests;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long UnitId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.UnitId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.Request2M_GetRequests)]
    public partial class Request2M_GetRequests : MessageObject, IResponse
    {
        public static Request2M_GetRequests Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Request2M_GetRequests), isFromPool) as Request2M_GetRequests;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public List<GameRequestInfo> GameRequestInfos { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.GameRequestInfos.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.Pay2M_Pay)]
    public partial class Pay2M_Pay : MessageObject, IMessage
    {
        public static Pay2M_Pay Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Pay2M_Pay), isFromPool) as Pay2M_Pay;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long UnitId { get; set; }

        [MemoryPackOrder(2)]
        public string ProductId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.UnitId = default;
            this.ProductId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    public static partial class InnerMessage
    {
        public const ushort ObjectQueryRequest = 20002;
        public const ushort M2A_Reload = 20003;
        public const ushort A2M_Reload = 20004;
        public const ushort G2G_LockRequest = 20005;
        public const ushort G2G_LockResponse = 20006;
        public const ushort G2G_LockReleaseRequest = 20007;
        public const ushort G2G_LockReleaseResponse = 20008;
        public const ushort ObjectAddRequest = 20009;
        public const ushort ObjectAddResponse = 20010;
        public const ushort ObjectLockRequest = 20011;
        public const ushort ObjectLockResponse = 20012;
        public const ushort ObjectUnLockRequest = 20013;
        public const ushort ObjectUnLockResponse = 20014;
        public const ushort ObjectRemoveRequest = 20015;
        public const ushort ObjectRemoveResponse = 20016;
        public const ushort ObjectGetRequest = 20017;
        public const ushort ObjectGetResponse = 20018;
        public const ushort R2G_GetLoginKey = 20019;
        public const ushort G2R_GetLoginKey = 20020;
        public const ushort G2M_SessionDisconnect = 20021;
        public const ushort ObjectQueryResponse = 20022;
        public const ushort M2M_UnitTransferRequest = 20023;
        public const ushort M2M_UnitTransferResponse = 20024;
        public const ushort Other2DBCache_AddOrUpdateUnitCache = 20025;
        public const ushort Other2DBCache_GetEntities = 20026;
        public const ushort DBCache2Other_GetEntities = 20027;
        public const ushort Rank_FightScore = 20028;
        public const ushort Map2Rank_UpdateScore = 20029;
        public const ushort M2M_ChatBroadcast = 20030;
        public const ushort GuildInfo = 20031;
        public const ushort GuildMemberInfo = 20032;
        public const ushort M2G_CreateGuild = 20033;
        public const ushort G2M_CreateGuild = 20034;
        public const ushort M2G_GetAllGuilds = 20035;
        public const ushort G2M_GetAllGuilds = 20036;
        public const ushort M2G_RequestJoinGuild = 20037;
        public const ushort G2M_RequestJoinGuild = 20038;
        public const ushort M2G_RequestQuitGuild = 20039;
        public const ushort G2M_RequestQuitGuild = 20040;
        public const ushort NewDayNotify = 20041;
        public const ushort DailyNotify = 20042;
        public const ushort GameRequestInfo = 20043;
        public const ushort Manager2Request_ShutDown = 20044;
        public const ushort Request2Manager_ShutDown = 20045;
        public const ushort M2Request_AddRequest = 20046;
        public const ushort Request2M_AddRequest = 20047;
        public const ushort M2Request_GetRequests = 20048;
        public const ushort Request2M_GetRequests = 20049;
        public const ushort Pay2M_Pay = 20050;
    }
}