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

    [MemoryPackable]
    [Message(OuterMessage.C2M_ChatBroadcast)]
    public partial class C2M_ChatBroadcast : MessageObject, ILocationMessage
    {
        public static C2M_ChatBroadcast Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_ChatBroadcast), isFromPool) as C2M_ChatBroadcast;
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
    [Message(OuterMessage.M2C_ChatBroadcast)]
    public partial class M2C_ChatBroadcast : MessageObject, IMessage
    {
        public static M2C_ChatBroadcast Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_ChatBroadcast), isFromPool) as M2C_ChatBroadcast;
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
    [Message(OuterMessage.OfflineIncomeInfo)]
    public partial class OfflineIncomeInfo : MessageObject
    {
        public static OfflineIncomeInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(OfflineIncomeInfo), isFromPool) as OfflineIncomeInfo;
        }

        [MemoryPackOrder(0)]
        public long Gold { get; set; }

        [MemoryPackOrder(1)]
        public long Exp { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Gold = default;
            this.Exp = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_GetOfflineIncome)]
    [ResponseType(nameof(M2C_GetOfflineIncome))]
    public partial class C2M_GetOfflineIncome : MessageObject, ILocationRequest
    {
        public static C2M_GetOfflineIncome Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_GetOfflineIncome), isFromPool) as C2M_GetOfflineIncome;
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
    [Message(OuterMessage.M2C_GetOfflineIncome)]
    public partial class M2C_GetOfflineIncome : MessageObject, ILocationResponse
    {
        public static M2C_GetOfflineIncome Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_GetOfflineIncome), isFromPool) as M2C_GetOfflineIncome;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public OfflineIncomeInfo OfflineIncomeInfo { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.OfflineIncomeInfo = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_SystemTips)]
    public partial class M2C_SystemTips : MessageObject, IMessage
    {
        public static M2C_SystemTips Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_SystemTips), isFromPool) as M2C_SystemTips;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int ErrorCode { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ErrorCode = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.BuildingInfo)]
    public partial class BuildingInfo : MessageObject
    {
        public static BuildingInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(BuildingInfo), isFromPool) as BuildingInfo;
        }

        [MemoryPackOrder(0)]
        public int ConfigId { get; set; }

        [MemoryPackOrder(1)]
        public int Level { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.ConfigId = default;
            this.Level = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_GetBuildings)]
    [ResponseType(nameof(M2C_GetBuildings))]
    public partial class C2M_GetBuildings : MessageObject, ILocationRequest
    {
        public static C2M_GetBuildings Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_GetBuildings), isFromPool) as C2M_GetBuildings;
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
    [Message(OuterMessage.M2C_GetBuildings)]
    public partial class M2C_GetBuildings : MessageObject, ILocationResponse
    {
        public static M2C_GetBuildings Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_GetBuildings), isFromPool) as M2C_GetBuildings;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public List<BuildingInfo> Buildings { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.Buildings.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_UpgradeBuilding)]
    [ResponseType(nameof(M2C_UpgradeBuilding))]
    public partial class C2M_UpgradeBuilding : MessageObject, ILocationRequest
    {
        public static C2M_UpgradeBuilding Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_UpgradeBuilding), isFromPool) as C2M_UpgradeBuilding;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long InstanceId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.InstanceId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_UpgradeBuilding)]
    public partial class M2C_UpgradeBuilding : MessageObject, ILocationResponse
    {
        public static M2C_UpgradeBuilding Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_UpgradeBuilding), isFromPool) as M2C_UpgradeBuilding;
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
    [Message(OuterMessage.C2M_LearnAvocation)]
    public partial class C2M_LearnAvocation : MessageObject, ILocationMessage
    {
        public static C2M_LearnAvocation Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_LearnAvocation), isFromPool) as C2M_LearnAvocation;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int AvocationType { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.AvocationType = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_UpgradeAvocation)]
    public partial class C2M_UpgradeAvocation : MessageObject, ILocationMessage
    {
        public static C2M_UpgradeAvocation Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_UpgradeAvocation), isFromPool) as C2M_UpgradeAvocation;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int AvocationType { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.AvocationType = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.CurrencyInfo)]
    public partial class CurrencyInfo : MessageObject
    {
        public static CurrencyInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(CurrencyInfo), isFromPool) as CurrencyInfo;
        }

        [MemoryPackOrder(0)]
        public int Type { get; set; }

        [MemoryPackOrder(1)]
        public long Value { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Type = default;
            this.Value = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_GetAllCurrencies)]
    [ResponseType(nameof(M2C_GetAllCurrencies))]
    public partial class C2M_GetAllCurrencies : MessageObject, ILocationRequest
    {
        public static C2M_GetAllCurrencies Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_GetAllCurrencies), isFromPool) as C2M_GetAllCurrencies;
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
    [Message(OuterMessage.M2C_GetAllCurrencies)]
    public partial class M2C_GetAllCurrencies : MessageObject, ILocationResponse
    {
        public static M2C_GetAllCurrencies Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_GetAllCurrencies), isFromPool) as M2C_GetAllCurrencies;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public List<CurrencyInfo> CurrencyInfos { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.CurrencyInfos.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.TalentInfo)]
    public partial class TalentInfo : MessageObject
    {
        public static TalentInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(TalentInfo), isFromPool) as TalentInfo;
        }

        [MemoryPackOrder(0)]
        public int ConfigId { get; set; }

        [MemoryPackOrder(1)]
        public int Level { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.ConfigId = default;
            this.Level = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_GetAllTalents)]
    [ResponseType(nameof(M2C_GetAllTalents))]
    public partial class C2M_GetAllTalents : MessageObject, ILocationRequest
    {
        public static C2M_GetAllTalents Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_GetAllTalents), isFromPool) as C2M_GetAllTalents;
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
    [Message(OuterMessage.M2C_GetAllTalents)]
    public partial class M2C_GetAllTalents : MessageObject, ILocationResponse
    {
        public static M2C_GetAllTalents Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_GetAllTalents), isFromPool) as M2C_GetAllTalents;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public List<TalentInfo> TalentInfos { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.TalentInfos.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.EquipmentRandomProperty)]
    public partial class EquipmentRandomProperty : MessageObject
    {
        public static EquipmentRandomProperty Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(EquipmentRandomProperty), isFromPool) as EquipmentRandomProperty;
        }

        [MemoryPackOrder(0)]
        public int GamePropertyType { get; set; }

        [MemoryPackOrder(1)]
        public long GamePropertyValue { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.GamePropertyType = default;
            this.GamePropertyValue = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_RerandomEquipmentProperties)]
    [ResponseType(nameof(M2C_RerandomEquipmentProperties))]
    public partial class C2M_RerandomEquipmentProperties : MessageObject, ILocationRequest
    {
        public static C2M_RerandomEquipmentProperties Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_RerandomEquipmentProperties), isFromPool) as C2M_RerandomEquipmentProperties;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int EquipmentConfigId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.EquipmentConfigId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_RerandomEquipmentProperties)]
    public partial class M2C_RerandomEquipmentProperties : MessageObject, ILocationResponse
    {
        public static M2C_RerandomEquipmentProperties Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_RerandomEquipmentProperties), isFromPool) as M2C_RerandomEquipmentProperties;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public List<EquipmentRandomProperty> EquipmentRandomProperties { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.EquipmentRandomProperties.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.TeamInfo)]
    public partial class TeamInfo : MessageObject
    {
        public static TeamInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(TeamInfo), isFromPool) as TeamInfo;
        }

        [MemoryPackOrder(0)]
        public long TeamId { get; set; }

        [MemoryPackOrder(1)]
        public long TeamLeaderId { get; set; }

        [MemoryPackOrder(2)]
        public List<long> TeamMemberIds { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.TeamId = default;
            this.TeamLeaderId = default;
            this.TeamMemberIds.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2T_CreateTeam)]
    [ResponseType(nameof(T2C_CreateTeam))]
    public partial class C2T_CreateTeam : MessageObject, IRequest
    {
        public static C2T_CreateTeam Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2T_CreateTeam), isFromPool) as C2T_CreateTeam;
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
    [Message(OuterMessage.T2C_CreateTeam)]
    public partial class T2C_CreateTeam : MessageObject, IResponse
    {
        public static T2C_CreateTeam Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(T2C_CreateTeam), isFromPool) as T2C_CreateTeam;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public long TeamId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.TeamId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2T_JoinTeam)]
    [ResponseType(nameof(T2C_JoinTeam))]
    public partial class C2T_JoinTeam : MessageObject, IRequest
    {
        public static C2T_JoinTeam Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2T_JoinTeam), isFromPool) as C2T_JoinTeam;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long TeamId { get; set; }

        [MemoryPackOrder(2)]
        public long UnitId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.TeamId = default;
            this.UnitId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.T2C_JoinTeam)]
    public partial class T2C_JoinTeam : MessageObject, IResponse
    {
        public static T2C_JoinTeam Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(T2C_JoinTeam), isFromPool) as T2C_JoinTeam;
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
    [Message(OuterMessage.C2T_QuitTeam)]
    [ResponseType(nameof(T2C_QuitTeam))]
    public partial class C2T_QuitTeam : MessageObject, IRequest
    {
        public static C2T_QuitTeam Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2T_QuitTeam), isFromPool) as C2T_QuitTeam;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long TeamId { get; set; }

        [MemoryPackOrder(2)]
        public long UnitId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.TeamId = default;
            this.UnitId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.T2C_QuitTeam)]
    public partial class T2C_QuitTeam : MessageObject, IResponse
    {
        public static T2C_QuitTeam Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(T2C_QuitTeam), isFromPool) as T2C_QuitTeam;
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
    [Message(OuterMessage.C2T_GetTeams)]
    [ResponseType(nameof(T2C_GetTeams))]
    public partial class C2T_GetTeams : MessageObject, IRequest
    {
        public static C2T_GetTeams Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2T_GetTeams), isFromPool) as C2T_GetTeams;
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
    [Message(OuterMessage.T2C_GetTeams)]
    public partial class T2C_GetTeams : MessageObject, IResponse
    {
        public static T2C_GetTeams Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(T2C_GetTeams), isFromPool) as T2C_GetTeams;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public List<TeamInfo> TeamInfos { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.TeamInfos.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.ShopItemInfo)]
    public partial class ShopItemInfo : MessageObject
    {
        public static ShopItemInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(ShopItemInfo), isFromPool) as ShopItemInfo;
        }

        [MemoryPackOrder(0)]
        public int ItemConfig { get; set; }

        [MemoryPackOrder(1)]
        public long ItemAmount { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.ItemConfig = default;
            this.ItemAmount = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_ShopItems)]
    [ResponseType(nameof(M2C_ShopItems))]
    public partial class C2M_ShopItems : MessageObject, ILocationRequest
    {
        public static C2M_ShopItems Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_ShopItems), isFromPool) as C2M_ShopItems;
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
    [Message(OuterMessage.M2C_ShopItems)]
    public partial class M2C_ShopItems : MessageObject, ILocationResponse
    {
        public static M2C_ShopItems Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_ShopItems), isFromPool) as M2C_ShopItems;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public List<ShopItemInfo> ShopItemInfos { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.ShopItemInfos.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_BuyItem)]
    [ResponseType(nameof(M2C_BuyItem))]
    public partial class C2M_BuyItem : MessageObject, ILocationRequest
    {
        public static C2M_BuyItem Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_BuyItem), isFromPool) as C2M_BuyItem;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int ItemConfig { get; set; }

        [MemoryPackOrder(2)]
        public long ItemAmount { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ItemConfig = default;
            this.ItemAmount = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_BuyItem)]
    public partial class M2C_BuyItem : MessageObject, ILocationResponse
    {
        public static M2C_BuyItem Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_BuyItem), isFromPool) as M2C_BuyItem;
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
        public const ushort C2M_GMCommand = 11002;
        public const ushort C2M_Signin = 11003;
        public const ushort M2C_Signin = 11004;
        public const ushort C2M_ChatBroadcast = 11005;
        public const ushort M2C_ChatBroadcast = 11006;
        public const ushort OfflineIncomeInfo = 11007;
        public const ushort C2M_GetOfflineIncome = 11008;
        public const ushort M2C_GetOfflineIncome = 11009;
        public const ushort M2C_SystemTips = 11010;
        public const ushort BuildingInfo = 11011;
        public const ushort C2M_GetBuildings = 11012;
        public const ushort M2C_GetBuildings = 11013;
        public const ushort C2M_UpgradeBuilding = 11014;
        public const ushort M2C_UpgradeBuilding = 11015;
        public const ushort C2M_LearnAvocation = 11016;
        public const ushort C2M_UpgradeAvocation = 11017;
        public const ushort CurrencyInfo = 11018;
        public const ushort C2M_GetAllCurrencies = 11019;
        public const ushort M2C_GetAllCurrencies = 11020;
        public const ushort TalentInfo = 11021;
        public const ushort C2M_GetAllTalents = 11022;
        public const ushort M2C_GetAllTalents = 11023;
        public const ushort EquipmentRandomProperty = 11024;
        public const ushort C2M_RerandomEquipmentProperties = 11025;
        public const ushort M2C_RerandomEquipmentProperties = 11026;
        public const ushort TeamInfo = 11027;
        public const ushort C2T_CreateTeam = 11028;
        public const ushort T2C_CreateTeam = 11029;
        public const ushort C2T_JoinTeam = 11030;
        public const ushort T2C_JoinTeam = 11031;
        public const ushort C2T_QuitTeam = 11032;
        public const ushort T2C_QuitTeam = 11033;
        public const ushort C2T_GetTeams = 11034;
        public const ushort T2C_GetTeams = 11035;
        public const ushort ShopItemInfo = 11036;
        public const ushort C2M_ShopItems = 11037;
        public const ushort M2C_ShopItems = 11038;
        public const ushort C2M_BuyItem = 11039;
        public const ushort M2C_BuyItem = 11040;
    }
}