using MemoryPack;
using System.Collections.Generic;

namespace ET
{
    [MemoryPackable]
    [Message(ClientMessage.RemoteConfig)]
    public partial class RemoteConfig : MessageObject
    {
        public static RemoteConfig Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(RemoteConfig), isFromPool) as RemoteConfig;
        }

        [MemoryPackOrder(0)]
        public bool DebugMode { get; set; }

        [MemoryPackOrder(1)]
        public string QualityUrl { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.DebugMode = default;
            this.QualityUrl = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(ClientMessage.AndroidQualityRule)]
    public partial class AndroidQualityRule : MessageObject
    {
        public static AndroidQualityRule Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(AndroidQualityRule), isFromPool) as AndroidQualityRule;
        }

        [MemoryPackOrder(0)]
        public int Quality { get; set; }

        [MemoryPackOrder(1)]
        public int FrameRate { get; set; }

        [MemoryPackOrder(2)]
        public int ScreenWidth { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Quality = default;
            this.FrameRate = default;
            this.ScreenWidth = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(ClientMessage.iOSQualityRule)]
    public partial class iOSQualityRule : MessageObject
    {
        public static iOSQualityRule Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(iOSQualityRule), isFromPool) as iOSQualityRule;
        }

        [MemoryPackOrder(0)]
        public int Quality { get; set; }

        [MemoryPackOrder(1)]
        public int FrameRate { get; set; }

        [MemoryPackOrder(2)]
        public int ScreenWidth { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Quality = default;
            this.FrameRate = default;
            this.ScreenWidth = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(ClientMessage.QualityConfig)]
    public partial class QualityConfig : MessageObject
    {
        public static QualityConfig Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(QualityConfig), isFromPool) as QualityConfig;
        }

        [MemoryPackOrder(0)]
        public List<AndroidQualityRule> AndroidQualityRules { get; set; } = new();

        [MemoryPackOrder(1)]
        public List<iOSQualityRule> iOSQualityRules { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.AndroidQualityRules.Clear();
            this.iOSQualityRules.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(ClientMessage.NetClient2Main_Ping)]
    public partial class NetClient2Main_Ping : MessageObject, IMessage
    {
        public static NetClient2Main_Ping Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(NetClient2Main_Ping), isFromPool) as NetClient2Main_Ping;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long Ping { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Ping = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(ClientMessage.Main2NetClient_Login)]
    [ResponseType(nameof(NetClient2Main_Login))]
    public partial class Main2NetClient_Login : MessageObject, IRequest
    {
        public static Main2NetClient_Login Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Main2NetClient_Login), isFromPool) as Main2NetClient_Login;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int OwnerFiberId { get; set; }

        [MemoryPackOrder(2)]
        public string Account { get; set; }

        [MemoryPackOrder(3)]
        public string Password { get; set; }

        [MemoryPackOrder(4)]
        public string OpenId { get; set; }

        [MemoryPackOrder(5)]
        public string Platform { get; set; }

        [MemoryPackOrder(6)]
        public string Host { get; set; }

        [MemoryPackOrder(7)]
        public int Port { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.OwnerFiberId = default;
            this.Account = default;
            this.Password = default;
            this.OpenId = default;
            this.Platform = default;
            this.Host = default;
            this.Port = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(ClientMessage.NetClient2Main_Login)]
    public partial class NetClient2Main_Login : MessageObject, IResponse
    {
        public static NetClient2Main_Login Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(NetClient2Main_Login), isFromPool) as NetClient2Main_Login;
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
    [Message(ClientMessage.Servers)]
    public partial class Servers : MessageObject
    {
        public static Servers Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Servers), isFromPool) as Servers;
        }

        [MemoryPackOrder(0)]
        public int server_id { get; set; }

        [MemoryPackOrder(1)]
        public int server_state { get; set; }

        [MemoryPackOrder(2)]
        public int server_flag { get; set; }

        [MemoryPackOrder(3)]
        public string server_name { get; set; }

        [MemoryPackOrder(4)]
        public string server_addr { get; set; }

        [MemoryPackOrder(5)]
        public int server_port { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.server_id = default;
            this.server_state = default;
            this.server_flag = default;
            this.server_name = default;
            this.server_addr = default;
            this.server_port = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(ClientMessage.Districts)]
    public partial class Districts : MessageObject
    {
        public static Districts Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Districts), isFromPool) as Districts;
        }

        [MemoryPackOrder(0)]
        public string district_name { get; set; }

        [MemoryPackOrder(1)]
        public int district_group { get; set; }

        [MemoryPackOrder(2)]
        public List<Servers> servers { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.district_name = default;
            this.district_group = default;
            this.servers.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(ClientMessage.Maple_info)]
    public partial class Maple_info : MessageObject
    {
        public static Maple_info Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Maple_info), isFromPool) as Maple_info;
        }

        [MemoryPackOrder(0)]
        public List<Districts> districts { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.districts.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(ClientMessage.MapleResponse)]
    public partial class MapleResponse : MessageObject
    {
        public static MapleResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(MapleResponse), isFromPool) as MapleResponse;
        }

        [MemoryPackOrder(0)]
        public int code { get; set; }

        [MemoryPackOrder(1)]
        public string message { get; set; }

        [MemoryPackOrder(2)]
        public Maple_info maple_info { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.code = default;
            this.message = default;
            this.maple_info = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    public static partial class ClientMessage
    {
        public const ushort RemoteConfig = 1001;
        public const ushort AndroidQualityRule = 1002;
        public const ushort iOSQualityRule = 1003;
        public const ushort QualityConfig = 1004;
        public const ushort NetClient2Main_Ping = 1005;
        public const ushort Main2NetClient_Login = 1006;
        public const ushort NetClient2Main_Login = 1007;
        public const ushort Servers = 1008;
        public const ushort Districts = 1009;
        public const ushort Maple_info = 1010;
        public const ushort MapleResponse = 1011;
    }
}