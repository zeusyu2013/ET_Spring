using MemoryPack;
using System.Collections.Generic;

namespace ET
{
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

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(ClientMessage.MapleInfo)]
    public partial class MapleInfo : MessageObject
    {
        public static MapleInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(MapleInfo), isFromPool) as MapleInfo;
        }

        [MemoryPackOrder(0)]
        public List<DistrictInfo> DistrictInfos { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.DistrictInfos.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(ClientMessage.DistrictInfo)]
    public partial class DistrictInfo : MessageObject
    {
        public static DistrictInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(DistrictInfo), isFromPool) as DistrictInfo;
        }

        [MemoryPackOrder(0)]
        public int district_id { get; set; }

        [MemoryPackOrder(1)]
        public string district_name { get; set; }

        [MemoryPackOrder(2)]
        public int district_group { get; set; }

        [MemoryPackOrder(3)]
        public List<ServerInfo> ServerInfos { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.district_id = default;
            this.district_name = default;
            this.district_group = default;
            this.ServerInfos.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(ClientMessage.ServerInfo)]
    public partial class ServerInfo : MessageObject
    {
        public static ServerInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(ServerInfo), isFromPool) as ServerInfo;
        }

        [MemoryPackOrder(0)]
        public string game_version { get; set; }

        [MemoryPackOrder(1)]
        public string district_id { get; set; }

        [MemoryPackOrder(2)]
        public int server_id { get; set; }

        [MemoryPackOrder(3)]
        public int server_type { get; set; }

        [MemoryPackOrder(4)]
        public int server_state { get; set; }

        [MemoryPackOrder(5)]
        public int server_white { get; set; }

        [MemoryPackOrder(6)]
        public int server_flag { get; set; }

        [MemoryPackOrder(7)]
        public string server_name { get; set; }

        [MemoryPackOrder(8)]
        public string server_addr { get; set; }

        [MemoryPackOrder(9)]
        public int server_port { get; set; }

        [MemoryPackOrder(10)]
        public int server_group { get; set; }

        [MemoryPackOrder(11)]
        public string platform { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.game_version = default;
            this.district_id = default;
            this.server_id = default;
            this.server_type = default;
            this.server_state = default;
            this.server_white = default;
            this.server_flag = default;
            this.server_name = default;
            this.server_addr = default;
            this.server_port = default;
            this.server_group = default;
            this.platform = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    public static class ClientMessage
    {
        public const ushort Main2NetClient_Login = 1001;
        public const ushort NetClient2Main_Login = 1002;
        public const ushort MapleInfo = 1003;
        public const ushort DistrictInfo = 1004;
        public const ushort ServerInfo = 1005;
    }
}