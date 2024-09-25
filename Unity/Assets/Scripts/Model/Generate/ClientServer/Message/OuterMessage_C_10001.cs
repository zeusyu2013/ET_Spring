using MemoryPack;
using System.Collections.Generic;

namespace ET
{
    [MemoryPackable]
    [Message(OuterMessage.HttpGetRouterResponse)]
    public partial class HttpGetRouterResponse : MessageObject
    {
        public static HttpGetRouterResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(HttpGetRouterResponse), isFromPool) as HttpGetRouterResponse;
        }

        [MemoryPackOrder(0)]
        public List<string> Realms { get; set; } = new();

        [MemoryPackOrder(1)]
        public List<string> Routers { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Realms.Clear();
            this.Routers.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.RouterSync)]
    public partial class RouterSync : MessageObject
    {
        public static RouterSync Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(RouterSync), isFromPool) as RouterSync;
        }

        [MemoryPackOrder(0)]
        public uint ConnectId { get; set; }

        [MemoryPackOrder(1)]
        public string Address { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.ConnectId = default;
            this.Address = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_TestRequest)]
    [ResponseType(nameof(M2C_TestResponse))]
    public partial class C2M_TestRequest : MessageObject, ILocationRequest
    {
        public static C2M_TestRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_TestRequest), isFromPool) as C2M_TestRequest;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public string request { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.request = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_TestResponse)]
    public partial class M2C_TestResponse : MessageObject, IResponse
    {
        public static M2C_TestResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_TestResponse), isFromPool) as M2C_TestResponse;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public string response { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.response = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2G_EnterMap)]
    [ResponseType(nameof(G2C_EnterMap))]
    public partial class C2G_EnterMap : MessageObject, ISessionRequest
    {
        public static C2G_EnterMap Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2G_EnterMap), isFromPool) as C2G_EnterMap;
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
    [Message(OuterMessage.G2C_EnterMap)]
    public partial class G2C_EnterMap : MessageObject, ISessionResponse
    {
        public static G2C_EnterMap Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2C_EnterMap), isFromPool) as G2C_EnterMap;
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
    [Message(OuterMessage.MoveInfo)]
    public partial class MoveInfo : MessageObject
    {
        public static MoveInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(MoveInfo), isFromPool) as MoveInfo;
        }

        [MemoryPackOrder(0)]
        public List<Unity.Mathematics.float3> Points { get; set; } = new();

        [MemoryPackOrder(1)]
        public Unity.Mathematics.quaternion Rotation { get; set; }

        [MemoryPackOrder(2)]
        public int TurnSpeed { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Points.Clear();
            this.Rotation = default;
            this.TurnSpeed = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.UnitInfo)]
    public partial class UnitInfo : MessageObject
    {
        public static UnitInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(UnitInfo), isFromPool) as UnitInfo;
        }

        [MemoryPackOrder(0)]
        public long PlayerId { get; set; }

        [MemoryPackOrder(1)]
        public long UnitId { get; set; }

        [MemoryPackOrder(2)]
        public int ConfigId { get; set; }

        [MemoryPackOrder(3)]
        public int Type { get; set; }

        [MemoryPackOrder(4)]
        public Unity.Mathematics.float3 Position { get; set; }

        [MemoryPackOrder(5)]
        public Unity.Mathematics.float3 Forward { get; set; }

        [MongoDB.Bson.Serialization.Attributes.BsonDictionaryOptions(MongoDB.Bson.Serialization.Options.DictionaryRepresentation.ArrayOfArrays)]
        [MemoryPackOrder(6)]
        public Dictionary<int, long> KV { get; set; } = new();
        [MemoryPackOrder(7)]
        public MoveInfo MoveInfo { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.PlayerId = default;
            this.UnitId = default;
            this.ConfigId = default;
            this.Type = default;
            this.Position = default;
            this.Forward = default;
            this.KV.Clear();
            this.MoveInfo = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_CreateUnits)]
    public partial class M2C_CreateUnits : MessageObject, IMessage
    {
        public static M2C_CreateUnits Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_CreateUnits), isFromPool) as M2C_CreateUnits;
        }

        [MemoryPackOrder(0)]
        public List<UnitInfo> Units { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Units.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_CreateMyUnit)]
    public partial class M2C_CreateMyUnit : MessageObject, IMessage
    {
        public static M2C_CreateMyUnit Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_CreateMyUnit), isFromPool) as M2C_CreateMyUnit;
        }

        [MemoryPackOrder(0)]
        public UnitInfo Unit { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Unit = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_StartSceneChange)]
    public partial class M2C_StartSceneChange : MessageObject, IMessage
    {
        public static M2C_StartSceneChange Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_StartSceneChange), isFromPool) as M2C_StartSceneChange;
        }

        [MemoryPackOrder(0)]
        public long SceneInstanceId { get; set; }

        [MemoryPackOrder(1)]
        public string SceneName { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.SceneInstanceId = default;
            this.SceneName = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_RemoveUnits)]
    public partial class M2C_RemoveUnits : MessageObject, IMessage
    {
        public static M2C_RemoveUnits Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_RemoveUnits), isFromPool) as M2C_RemoveUnits;
        }

        [MemoryPackOrder(0)]
        public List<long> Units { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Units.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_PathfindingResult)]
    public partial class C2M_PathfindingResult : MessageObject, ILocationMessage
    {
        public static C2M_PathfindingResult Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_PathfindingResult), isFromPool) as C2M_PathfindingResult;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public Unity.Mathematics.float3 Position { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Position = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_Stop)]
    public partial class C2M_Stop : MessageObject, ILocationMessage
    {
        public static C2M_Stop Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_Stop), isFromPool) as C2M_Stop;
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
    [Message(OuterMessage.M2C_PathfindingResult)]
    public partial class M2C_PathfindingResult : MessageObject, IMessage
    {
        public static M2C_PathfindingResult Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_PathfindingResult), isFromPool) as M2C_PathfindingResult;
        }

        [MemoryPackOrder(0)]
        public long Id { get; set; }

        [MemoryPackOrder(1)]
        public List<Unity.Mathematics.float3> Points { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Id = default;
            this.Points.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_Stop)]
    public partial class M2C_Stop : MessageObject, IMessage
    {
        public static M2C_Stop Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_Stop), isFromPool) as M2C_Stop;
        }

        [MemoryPackOrder(0)]
        public int Error { get; set; }

        [MemoryPackOrder(1)]
        public long Id { get; set; }

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

            this.Error = default;
            this.Id = default;
            this.Position = default;
            this.Rotation = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_JoyStop)]
    public partial class C2M_JoyStop : MessageObject, ILocationMessage
    {
        public static C2M_JoyStop Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_JoyStop), isFromPool) as C2M_JoyStop;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long UnitId { get; set; }

        [MemoryPackOrder(2)]
        public Unity.Mathematics.float3 Position { get; set; }

        [MemoryPackOrder(3)]
        public Unity.Mathematics.float3 Direction { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.UnitId = default;
            this.Position = default;
            this.Direction = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2G_Ping)]
    [ResponseType(nameof(G2C_Ping))]
    public partial class C2G_Ping : MessageObject, ISessionRequest
    {
        public static C2G_Ping Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2G_Ping), isFromPool) as C2G_Ping;
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
    [Message(OuterMessage.G2C_Ping)]
    public partial class G2C_Ping : MessageObject, ISessionResponse
    {
        public static G2C_Ping Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2C_Ping), isFromPool) as G2C_Ping;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public long Time { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.Time = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.G2C_Test)]
    public partial class G2C_Test : MessageObject, ISessionMessage
    {
        public static G2C_Test Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2C_Test), isFromPool) as G2C_Test;
        }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            
            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_Reload)]
    [ResponseType(nameof(M2C_Reload))]
    public partial class C2M_Reload : MessageObject, ISessionRequest
    {
        public static C2M_Reload Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_Reload), isFromPool) as C2M_Reload;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public string Account { get; set; }

        [MemoryPackOrder(2)]
        public string Password { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Account = default;
            this.Password = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_Reload)]
    public partial class M2C_Reload : MessageObject, ISessionResponse
    {
        public static M2C_Reload Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_Reload), isFromPool) as M2C_Reload;
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
    [Message(OuterMessage.C2R_Login)]
    [ResponseType(nameof(R2C_Login))]
    public partial class C2R_Login : MessageObject, ISessionRequest
    {
        public static C2R_Login Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2R_Login), isFromPool) as C2R_Login;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        /// <summary>
        /// 帐号
        /// </summary>
        [MemoryPackOrder(1)]
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [MemoryPackOrder(2)]
        public string Password { get; set; }

        /// <summary>
        /// open id
        /// </summary>
        [MemoryPackOrder(3)]
        public string OpenId { get; set; }

        /// <summary>
        /// 平台
        /// </summary>
        [MemoryPackOrder(4)]
        public string Platform { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Account = default;
            this.Password = default;
            this.OpenId = default;
            this.Platform = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.R2C_Login)]
    public partial class R2C_Login : MessageObject, ISessionResponse
    {
        public static R2C_Login Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(R2C_Login), isFromPool) as R2C_Login;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public string Address { get; set; }

        [MemoryPackOrder(4)]
        public long Key { get; set; }

        [MemoryPackOrder(5)]
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
            this.Address = default;
            this.Key = default;
            this.GateId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2G_LoginGate)]
    [ResponseType(nameof(G2C_LoginGate))]
    public partial class C2G_LoginGate : MessageObject, ISessionRequest
    {
        public static C2G_LoginGate Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2G_LoginGate), isFromPool) as C2G_LoginGate;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        /// <summary>
        /// 帐号
        /// </summary>
        [MemoryPackOrder(1)]
        public long Key { get; set; }

        [MemoryPackOrder(2)]
        public long GateId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Key = default;
            this.GateId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.G2C_LoginGate)]
    public partial class G2C_LoginGate : MessageObject, ISessionResponse
    {
        public static G2C_LoginGate Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2C_LoginGate), isFromPool) as G2C_LoginGate;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public long PlayerId { get; set; }

        [MemoryPackOrder(4)]
        public long UnitId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.PlayerId = default;
            this.UnitId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.G2C_TestHotfixMessage)]
    public partial class G2C_TestHotfixMessage : MessageObject, ISessionMessage
    {
        public static G2C_TestHotfixMessage Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2C_TestHotfixMessage), isFromPool) as G2C_TestHotfixMessage;
        }

        [MemoryPackOrder(0)]
        public string Info { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Info = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_TestRobotCase)]
    [ResponseType(nameof(M2C_TestRobotCase))]
    public partial class C2M_TestRobotCase : MessageObject, ILocationRequest
    {
        public static C2M_TestRobotCase Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_TestRobotCase), isFromPool) as C2M_TestRobotCase;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int N { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.N = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_TestRobotCase)]
    public partial class M2C_TestRobotCase : MessageObject, ILocationResponse
    {
        public static M2C_TestRobotCase Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_TestRobotCase), isFromPool) as M2C_TestRobotCase;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public int N { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.N = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_TestRobotCase2)]
    public partial class C2M_TestRobotCase2 : MessageObject, ILocationMessage
    {
        public static C2M_TestRobotCase2 Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_TestRobotCase2), isFromPool) as C2M_TestRobotCase2;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int N { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.N = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_TestRobotCase2)]
    public partial class M2C_TestRobotCase2 : MessageObject, ILocationMessage
    {
        public static M2C_TestRobotCase2 Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_TestRobotCase2), isFromPool) as M2C_TestRobotCase2;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int N { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.N = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_TransferMap)]
    [ResponseType(nameof(M2C_TransferMap))]
    public partial class C2M_TransferMap : MessageObject, ILocationRequest
    {
        public static C2M_TransferMap Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_TransferMap), isFromPool) as C2M_TransferMap;
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
    [Message(OuterMessage.M2C_TransferMap)]
    public partial class M2C_TransferMap : MessageObject, ILocationResponse
    {
        public static M2C_TransferMap Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_TransferMap), isFromPool) as M2C_TransferMap;
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
    [Message(OuterMessage.C2M_CreateDungeon)]
    [ResponseType(nameof(M2C_CreateDungeon))]
    public partial class C2M_CreateDungeon : MessageObject, ILocationRequest
    {
        public static C2M_CreateDungeon Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_CreateDungeon), isFromPool) as C2M_CreateDungeon;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int DungeonConfig { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.DungeonConfig = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_CreateDungeon)]
    public partial class M2C_CreateDungeon : MessageObject, ILocationResponse
    {
        public static M2C_CreateDungeon Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_CreateDungeon), isFromPool) as M2C_CreateDungeon;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
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
            this.ActorId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_TransferDungeon)]
    [ResponseType(nameof(M2C_TransferDungeon))]
    public partial class C2M_TransferDungeon : MessageObject, ILocationRequest
    {
        public static C2M_TransferDungeon Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_TransferDungeon), isFromPool) as C2M_TransferDungeon;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public ActorId ActorId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_TransferDungeon)]
    public partial class M2C_TransferDungeon : MessageObject, ILocationResponse
    {
        public static M2C_TransferDungeon Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_TransferDungeon), isFromPool) as M2C_TransferDungeon;
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
    [Message(OuterMessage.C2M_ExitDungeon)]
    [ResponseType(nameof(M2C_ExitDungeon))]
    public partial class C2M_ExitDungeon : MessageObject, ILocationRequest
    {
        public static C2M_ExitDungeon Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_ExitDungeon), isFromPool) as C2M_ExitDungeon;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public ActorId ActorId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_ExitDungeon)]
    public partial class M2C_ExitDungeon : MessageObject, ILocationResponse
    {
        public static M2C_ExitDungeon Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_ExitDungeon), isFromPool) as M2C_ExitDungeon;
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
    [Message(OuterMessage.M2C_DungeonTimeout)]
    public partial class M2C_DungeonTimeout : MessageObject, IMessage
    {
        public static M2C_DungeonTimeout Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_DungeonTimeout), isFromPool) as M2C_DungeonTimeout;
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
    [Message(OuterMessage.C2G_Benchmark)]
    [ResponseType(nameof(G2C_Benchmark))]
    public partial class C2G_Benchmark : MessageObject, ISessionRequest
    {
        public static C2G_Benchmark Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2G_Benchmark), isFromPool) as C2G_Benchmark;
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
    [Message(OuterMessage.G2C_Benchmark)]
    public partial class G2C_Benchmark : MessageObject, ISessionResponse
    {
        public static G2C_Benchmark Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2C_Benchmark), isFromPool) as G2C_Benchmark;
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
    [Message(OuterMessage.GameRoleInfo)]
    public partial class GameRoleInfo : MessageObject
    {
        public static GameRoleInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(GameRoleInfo), isFromPool) as GameRoleInfo;
        }

        [MemoryPackOrder(0)]
        public long PlayerId { get; set; }

        [MemoryPackOrder(1)]
        public long UnitId { get; set; }

        [MemoryPackOrder(2)]
        public string RoleName { get; set; }

        [MemoryPackOrder(3)]
        public int RoleLevel { get; set; }

        [MemoryPackOrder(4)]
        public int CharacterType { get; set; }

        [MemoryPackOrder(5)]
        public int RaceType { get; set; }

        [MemoryPackOrder(6)]
        public string RoleModel { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.PlayerId = default;
            this.UnitId = default;
            this.RoleName = default;
            this.RoleLevel = default;
            this.CharacterType = default;
            this.RaceType = default;
            this.RoleModel = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2G_GetRoles)]
    [ResponseType(nameof(G2C_GetRoles))]
    public partial class C2G_GetRoles : MessageObject, ISessionRequest
    {
        public static C2G_GetRoles Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2G_GetRoles), isFromPool) as C2G_GetRoles;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long PlayerId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.PlayerId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.G2C_GetRoles)]
    public partial class G2C_GetRoles : MessageObject, ISessionResponse
    {
        public static G2C_GetRoles Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2C_GetRoles), isFromPool) as G2C_GetRoles;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public List<GameRoleInfo> Roles { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.Roles.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2G_CreateRole)]
    [ResponseType(nameof(G2C_CreateRole))]
    public partial class C2G_CreateRole : MessageObject, ISessionRequest
    {
        public static C2G_CreateRole Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2G_CreateRole), isFromPool) as C2G_CreateRole;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long PlayerId { get; set; }

        [MemoryPackOrder(2)]
        public string RoleName { get; set; }

        [MemoryPackOrder(3)]
        public int CharacterType { get; set; }

        [MemoryPackOrder(4)]
        public int RaceType { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.PlayerId = default;
            this.RoleName = default;
            this.CharacterType = default;
            this.RaceType = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.G2C_CreateRole)]
    public partial class G2C_CreateRole : MessageObject, ISessionResponse
    {
        public static G2C_CreateRole Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2C_CreateRole), isFromPool) as G2C_CreateRole;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public List<GameRoleInfo> Roles { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.Roles.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2G_DeleteRole)]
    [ResponseType(nameof(G2C_DeleteRole))]
    public partial class C2G_DeleteRole : MessageObject, ISessionRequest
    {
        public static C2G_DeleteRole Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2G_DeleteRole), isFromPool) as C2G_DeleteRole;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long PlayerId { get; set; }

        [MemoryPackOrder(2)]
        public string RoleName { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.PlayerId = default;
            this.RoleName = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.G2C_DeleteRole)]
    public partial class G2C_DeleteRole : MessageObject, ISessionResponse
    {
        public static G2C_DeleteRole Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2C_DeleteRole), isFromPool) as G2C_DeleteRole;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public List<GameRoleInfo> Roles { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.Roles.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2G_ChooseRole)]
    [ResponseType(nameof(G2C_ChooseRole))]
    public partial class C2G_ChooseRole : MessageObject, IRequest
    {
        public static C2G_ChooseRole Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2G_ChooseRole), isFromPool) as C2G_ChooseRole;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long PlayerId { get; set; }

        [MemoryPackOrder(2)]
        public string RoleName { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.PlayerId = default;
            this.RoleName = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.G2C_ChooseRole)]
    public partial class G2C_ChooseRole : MessageObject, IResponse
    {
        public static G2C_ChooseRole Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2C_ChooseRole), isFromPool) as G2C_ChooseRole;
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
    [Message(OuterMessage.GameItemInfo)]
    public partial class GameItemInfo : MessageObject
    {
        public static GameItemInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(GameItemInfo), isFromPool) as GameItemInfo;
        }

        [MemoryPackOrder(0)]
        public int Config { get; set; }

        [MemoryPackOrder(1)]
        public long Amount { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Config = default;
            this.Amount = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_GetAllItems)]
    [ResponseType(nameof(M2C_GetAllItems))]
    public partial class C2M_GetAllItems : MessageObject, ILocationRequest
    {
        public static C2M_GetAllItems Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_GetAllItems), isFromPool) as C2M_GetAllItems;
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
    [Message(OuterMessage.M2C_GetAllItems)]
    public partial class M2C_GetAllItems : MessageObject, ILocationResponse
    {
        public static M2C_GetAllItems Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_GetAllItems), isFromPool) as M2C_GetAllItems;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public List<GameItemInfo> GameItemInfos { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.GameItemInfos.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_ExtendBag)]
    [ResponseType(nameof(M2C_ExtendBag))]
    public partial class C2M_ExtendBag : MessageObject, ILocationRequest
    {
        public static C2M_ExtendBag Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_ExtendBag), isFromPool) as C2M_ExtendBag;
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
    [Message(OuterMessage.M2C_ExtendBag)]
    public partial class M2C_ExtendBag : MessageObject, ILocationResponse
    {
        public static M2C_ExtendBag Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_ExtendBag), isFromPool) as M2C_ExtendBag;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public int MaxCapacity { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.MaxCapacity = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_UseItem)]
    public partial class C2M_UseItem : MessageObject, ILocationMessage
    {
        public static C2M_UseItem Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_UseItem), isFromPool) as C2M_UseItem;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int ConfigId { get; set; }

        [MemoryPackOrder(2)]
        public long Amount { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ConfigId = default;
            this.Amount = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_GetDropItems)]
    [ResponseType(nameof(M2C_GetDropItems))]
    public partial class C2M_GetDropItems : MessageObject, ILocationRequest
    {
        public static C2M_GetDropItems Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_GetDropItems), isFromPool) as C2M_GetDropItems;
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
    [Message(OuterMessage.M2C_GetDropItems)]
    public partial class M2C_GetDropItems : MessageObject, ILocationResponse
    {
        public static M2C_GetDropItems Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_GetDropItems), isFromPool) as M2C_GetDropItems;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public List<GameItemInfo> GameItemInfos { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.GameItemInfos.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_AssignmentDropItem)]
    [ResponseType(nameof(M2C_AssignmentDropItem))]
    public partial class C2M_AssignmentDropItem : MessageObject, ILocationRequest
    {
        public static C2M_AssignmentDropItem Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_AssignmentDropItem), isFromPool) as C2M_AssignmentDropItem;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long MonsterId { get; set; }

        [MemoryPackOrder(2)]
        public long UnitId { get; set; }

        [MemoryPackOrder(3)]
        public long TeamId { get; set; }

        [MemoryPackOrder(4)]
        public long AssignmentUnitId { get; set; }

        [MemoryPackOrder(5)]
        public int ItemConfigId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.MonsterId = default;
            this.UnitId = default;
            this.TeamId = default;
            this.AssignmentUnitId = default;
            this.ItemConfigId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_AssignmentDropItem)]
    public partial class M2C_AssignmentDropItem : MessageObject, ILocationResponse
    {
        public static M2C_AssignmentDropItem Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_AssignmentDropItem), isFromPool) as M2C_AssignmentDropItem;
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
    [Message(OuterMessage.C2M_AcceptTask)]
    [ResponseType(nameof(M2C_AcceptTask))]
    public partial class C2M_AcceptTask : MessageObject, ILocationRequest
    {
        public static C2M_AcceptTask Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_AcceptTask), isFromPool) as C2M_AcceptTask;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int TaskId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.TaskId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_AcceptTask)]
    public partial class M2C_AcceptTask : MessageObject, ILocationResponse
    {
        public static M2C_AcceptTask Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_AcceptTask), isFromPool) as M2C_AcceptTask;
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
    [Message(OuterMessage.C2M_CompleteTask)]
    [ResponseType(nameof(M2C_CompleteTask))]
    public partial class C2M_CompleteTask : MessageObject, ILocationRequest
    {
        public static C2M_CompleteTask Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_CompleteTask), isFromPool) as C2M_CompleteTask;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int TaskId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.TaskId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_CompleteTask)]
    public partial class M2C_CompleteTask : MessageObject, ILocationResponse
    {
        public static M2C_CompleteTask Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_CompleteTask), isFromPool) as M2C_CompleteTask;
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
    [Message(OuterMessage.GameBuffInfo)]
    public partial class GameBuffInfo : MessageObject
    {
        public static GameBuffInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(GameBuffInfo), isFromPool) as GameBuffInfo;
        }

        [MemoryPackOrder(0)]
        public int ConfigId { get; set; }

        [MemoryPackOrder(1)]
        public long Time { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.ConfigId = default;
            this.Time = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_GetAllBuffs)]
    [ResponseType(nameof(M2C_GetAllBuffs))]
    public partial class C2M_GetAllBuffs : MessageObject, ILocationRequest
    {
        public static C2M_GetAllBuffs Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_GetAllBuffs), isFromPool) as C2M_GetAllBuffs;
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
    [Message(OuterMessage.M2C_GetAllBuffs)]
    public partial class M2C_GetAllBuffs : MessageObject, ILocationResponse
    {
        public static M2C_GetAllBuffs Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_GetAllBuffs), isFromPool) as M2C_GetAllBuffs;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public List<GameBuffInfo> GameBuffInfos { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.GameBuffInfos.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_Equip)]
    [ResponseType(nameof(M2C_Equip))]
    public partial class C2M_Equip : MessageObject, ILocationRequest
    {
        public static C2M_Equip Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_Equip), isFromPool) as C2M_Equip;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int ConfigId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ConfigId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_Equip)]
    public partial class M2C_Equip : MessageObject, ILocationResponse
    {
        public static M2C_Equip Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_Equip), isFromPool) as M2C_Equip;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public int Index { get; set; }

        [MemoryPackOrder(4)]
        public int ConfigId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.Index = default;
            this.ConfigId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.GamePropertyInfo)]
    public partial class GamePropertyInfo : MessageObject
    {
        public static GamePropertyInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(GamePropertyInfo), isFromPool) as GamePropertyInfo;
        }

        [MemoryPackOrder(0)]
        public int PropertyType { get; set; }

        [MemoryPackOrder(1)]
        public long PropertyValue { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.PropertyType = default;
            this.PropertyValue = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_PropertyRefresh)]
    public partial class M2C_PropertyRefresh : MessageObject, IMessage
    {
        public static M2C_PropertyRefresh Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_PropertyRefresh), isFromPool) as M2C_PropertyRefresh;
        }

        [MemoryPackOrder(0)]
        public int PlayerId { get; set; }

        [MemoryPackOrder(1)]
        public List<GamePropertyInfo> GamePropertyInfos { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.PlayerId = default;
            this.GamePropertyInfos.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.FightScoreRankEntityInfo)]
    public partial class FightScoreRankEntityInfo : MessageObject
    {
        public static FightScoreRankEntityInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(FightScoreRankEntityInfo), isFromPool) as FightScoreRankEntityInfo;
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
    [Message(OuterMessage.C2Main_GetFightScoreRank)]
    [ResponseType(nameof(Main2C_GetFightScoreRank))]
    public partial class C2Main_GetFightScoreRank : MessageObject, IRequest
    {
        public static C2Main_GetFightScoreRank Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2Main_GetFightScoreRank), isFromPool) as C2Main_GetFightScoreRank;
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
    [Message(OuterMessage.Main2C_GetFightScoreRank)]
    public partial class Main2C_GetFightScoreRank : MessageObject, IResponse
    {
        public static Main2C_GetFightScoreRank Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Main2C_GetFightScoreRank), isFromPool) as Main2C_GetFightScoreRank;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public List<FightScoreRankEntityInfo> FightScoreRankEntityInfos { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.FightScoreRankEntityInfos.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.MailInfo)]
    public partial class MailInfo : MessageObject
    {
        public static MailInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(MailInfo), isFromPool) as MailInfo;
        }

        [MemoryPackOrder(0)]
        public string Title { get; set; }

        [MemoryPackOrder(1)]
        public string Content { get; set; }

        [MemoryPackOrder(2)]
        public List<GameItemInfo> Attachments { get; set; } = new();

        [MemoryPackOrder(3)]
        public bool Read { get; set; }

        [MemoryPackOrder(4)]
        public bool ReceiveAttachments { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Title = default;
            this.Content = default;
            this.Attachments.Clear();
            this.Read = default;
            this.ReceiveAttachments = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_CheckMails)]
    [ResponseType(nameof(M2C_CheckMails))]
    public partial class C2M_CheckMails : MessageObject, ILocationRequest
    {
        public static C2M_CheckMails Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_CheckMails), isFromPool) as C2M_CheckMails;
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
    [Message(OuterMessage.M2C_CheckMails)]
    public partial class M2C_CheckMails : MessageObject, ILocationResponse
    {
        public static M2C_CheckMails Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_CheckMails), isFromPool) as M2C_CheckMails;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public List<MailInfo> MailInfos { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.MailInfos.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_CheckMail)]
    [ResponseType(nameof(M2C_CheckMail))]
    public partial class C2M_CheckMail : MessageObject, ILocationRequest
    {
        public static C2M_CheckMail Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_CheckMail), isFromPool) as C2M_CheckMail;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long MailId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.MailId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_CheckMail)]
    public partial class M2C_CheckMail : MessageObject, ILocationResponse
    {
        public static M2C_CheckMail Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_CheckMail), isFromPool) as M2C_CheckMail;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public MailInfo MailInfo { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.MailInfo = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_ReceiveAttachments)]
    [ResponseType(nameof(M2C_ReceiveAttachments))]
    public partial class C2M_ReceiveAttachments : MessageObject, ILocationRequest
    {
        public static C2M_ReceiveAttachments Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_ReceiveAttachments), isFromPool) as C2M_ReceiveAttachments;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long MailId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.MailId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_ReceiveAttachments)]
    public partial class M2C_ReceiveAttachments : MessageObject, ILocationResponse
    {
        public static M2C_ReceiveAttachments Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_ReceiveAttachments), isFromPool) as M2C_ReceiveAttachments;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public MailInfo MailInfo { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.MailInfo = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    public static partial class OuterMessage
    {
        public const ushort HttpGetRouterResponse = 10002;
        public const ushort RouterSync = 10003;
        public const ushort C2M_TestRequest = 10004;
        public const ushort M2C_TestResponse = 10005;
        public const ushort C2G_EnterMap = 10006;
        public const ushort G2C_EnterMap = 10007;
        public const ushort MoveInfo = 10008;
        public const ushort UnitInfo = 10009;
        public const ushort M2C_CreateUnits = 10010;
        public const ushort M2C_CreateMyUnit = 10011;
        public const ushort M2C_StartSceneChange = 10012;
        public const ushort M2C_RemoveUnits = 10013;
        public const ushort C2M_PathfindingResult = 10014;
        public const ushort C2M_Stop = 10015;
        public const ushort M2C_PathfindingResult = 10016;
        public const ushort M2C_Stop = 10017;
        public const ushort C2M_JoyStop = 10018;
        public const ushort C2G_Ping = 10019;
        public const ushort G2C_Ping = 10020;
        public const ushort G2C_Test = 10021;
        public const ushort C2M_Reload = 10022;
        public const ushort M2C_Reload = 10023;
        public const ushort C2R_Login = 10024;
        public const ushort R2C_Login = 10025;
        public const ushort C2G_LoginGate = 10026;
        public const ushort G2C_LoginGate = 10027;
        public const ushort G2C_TestHotfixMessage = 10028;
        public const ushort C2M_TestRobotCase = 10029;
        public const ushort M2C_TestRobotCase = 10030;
        public const ushort C2M_TestRobotCase2 = 10031;
        public const ushort M2C_TestRobotCase2 = 10032;
        public const ushort C2M_TransferMap = 10033;
        public const ushort M2C_TransferMap = 10034;
        public const ushort C2M_CreateDungeon = 10035;
        public const ushort M2C_CreateDungeon = 10036;
        public const ushort C2M_TransferDungeon = 10037;
        public const ushort M2C_TransferDungeon = 10038;
        public const ushort C2M_ExitDungeon = 10039;
        public const ushort M2C_ExitDungeon = 10040;
        public const ushort M2C_DungeonTimeout = 10041;
        public const ushort C2G_Benchmark = 10042;
        public const ushort G2C_Benchmark = 10043;
        public const ushort GameRoleInfo = 10044;
        public const ushort C2G_GetRoles = 10045;
        public const ushort G2C_GetRoles = 10046;
        public const ushort C2G_CreateRole = 10047;
        public const ushort G2C_CreateRole = 10048;
        public const ushort C2G_DeleteRole = 10049;
        public const ushort G2C_DeleteRole = 10050;
        public const ushort C2G_ChooseRole = 10051;
        public const ushort G2C_ChooseRole = 10052;
        public const ushort GameItemInfo = 10053;
        public const ushort C2M_GetAllItems = 10054;
        public const ushort M2C_GetAllItems = 10055;
        public const ushort C2M_ExtendBag = 10056;
        public const ushort M2C_ExtendBag = 10057;
        public const ushort C2M_UseItem = 10058;
        public const ushort C2M_GetDropItems = 10059;
        public const ushort M2C_GetDropItems = 10060;
        public const ushort C2M_AssignmentDropItem = 10061;
        public const ushort M2C_AssignmentDropItem = 10062;
        public const ushort C2M_AcceptTask = 10063;
        public const ushort M2C_AcceptTask = 10064;
        public const ushort C2M_CompleteTask = 10065;
        public const ushort M2C_CompleteTask = 10066;
        public const ushort GameBuffInfo = 10067;
        public const ushort C2M_GetAllBuffs = 10068;
        public const ushort M2C_GetAllBuffs = 10069;
        public const ushort C2M_Equip = 10070;
        public const ushort M2C_Equip = 10071;
        public const ushort GamePropertyInfo = 10072;
        public const ushort M2C_PropertyRefresh = 10073;
        public const ushort FightScoreRankEntityInfo = 10074;
        public const ushort C2Main_GetFightScoreRank = 10075;
        public const ushort Main2C_GetFightScoreRank = 10076;
        public const ushort MailInfo = 10077;
        public const ushort C2M_CheckMails = 10078;
        public const ushort M2C_CheckMails = 10079;
        public const ushort C2M_CheckMail = 10080;
        public const ushort M2C_CheckMail = 10081;
        public const ushort C2M_ReceiveAttachments = 10082;
        public const ushort M2C_ReceiveAttachments = 10083;
    }
}