using System.Collections.Generic;
public class AOTGenericReferences : UnityEngine.MonoBehaviour
{

	// {{ AOT assemblies
	public static readonly IReadOnlyList<string> PatchedAOTAssemblyList = new List<string>
	{
		"Cinemachine.dll",
		"MemoryPack.dll",
		"MongoDB.Bson.dll",
		"System.Core.dll",
		"System.Runtime.CompilerServices.Unsafe.dll",
		"System.dll",
		"Unity.Core.dll",
		"Unity.Loader.dll",
		"Unity.ThirdParty.dll",
		"UnityEngine.CoreModule.dll",
		"YooAsset.dll",
		"mscorlib.dll",
	};
	// }}

	// {{ constraint implement type
	// }} 

	// {{ AOT generic types
	// ET.AEvent<object,ET.AppearanceChanged>
	// ET.AEvent<object,ET.BuffAdd>
	// ET.AEvent<object,ET.BuffRemove>
	// ET.AEvent<object,ET.BuffTick>
	// ET.AEvent<object,ET.BuffUpdate>
	// ET.AEvent<object,ET.CastBreak>
	// ET.AEvent<object,ET.CastFinish>
	// ET.AEvent<object,ET.CastHit>
	// ET.AEvent<object,ET.CastStart>
	// ET.AEvent<object,ET.ChangePosition>
	// ET.AEvent<object,ET.ChangeRotation>
	// ET.AEvent<object,ET.Client.AfterCreateClientScene>
	// ET.AEvent<object,ET.Client.AfterCreateCurrentScene>
	// ET.AEvent<object,ET.Client.AfterUnitCreate>
	// ET.AEvent<object,ET.Client.AppStartInitFinish>
	// ET.AEvent<object,ET.Client.ChooseServer>
	// ET.AEvent<object,ET.Client.EnterMapFinish>
	// ET.AEvent<object,ET.Client.GetAllItems>
	// ET.AEvent<object,ET.Client.HeightSync>
	// ET.AEvent<object,ET.Client.JoystickMove>
	// ET.AEvent<object,ET.Client.KeyDown>
	// ET.AEvent<object,ET.Client.LoginFinish>
	// ET.AEvent<object,ET.Client.MoveDelta>
	// ET.AEvent<object,ET.Client.RemoteConfigLoaded>
	// ET.AEvent<object,ET.Client.SceneChangeFinish>
	// ET.AEvent<object,ET.Client.SceneChangeStart>
	// ET.AEvent<object,ET.Client.UIPing>
	// ET.AEvent<object,ET.EntryEvent1>
	// ET.AEvent<object,ET.EntryEvent3>
	// ET.AEvent<object,ET.MoveStart>
	// ET.AEvent<object,ET.MoveStop>
	// ET.AEvent<object,ET.NumbericChange>
	// ET.AInvokeHandler<ET.FiberInit,object>
	// ET.AInvokeHandler<ET.MailBoxInvoker>
	// ET.AInvokeHandler<ET.NetComponentOnRead>
	// ET.AInvokeHandler<ET.TimerCallback>
	// ET.ATimer<object>
	// ET.AwakeSystem<object,int,int>
	// ET.AwakeSystem<object,int>
	// ET.AwakeSystem<object,object,int>
	// ET.AwakeSystem<object,object,object>
	// ET.AwakeSystem<object,object>
	// ET.AwakeSystem<object>
	// ET.DeserializeSystem<object>
	// ET.DestroySystem<object>
	// ET.ETAsyncTaskMethodBuilder<ET.Client.Wait_CreateMyUnit>
	// ET.ETAsyncTaskMethodBuilder<ET.Client.Wait_SceneChangeFinish>
	// ET.ETAsyncTaskMethodBuilder<ET.Client.Wait_UnitStop>
	// ET.ETAsyncTaskMethodBuilder<System.ValueTuple<long,long>>
	// ET.ETAsyncTaskMethodBuilder<System.ValueTuple<uint,object>>
	// ET.ETAsyncTaskMethodBuilder<byte>
	// ET.ETAsyncTaskMethodBuilder<int>
	// ET.ETAsyncTaskMethodBuilder<object>
	// ET.ETAsyncTaskMethodBuilder<uint>
	// ET.ETTask<ET.Client.Wait_CreateMyUnit>
	// ET.ETTask<ET.Client.Wait_SceneChangeFinish>
	// ET.ETTask<ET.Client.Wait_UnitStop>
	// ET.ETTask<System.ValueTuple<long,long>>
	// ET.ETTask<System.ValueTuple<uint,object>>
	// ET.ETTask<byte>
	// ET.ETTask<int>
	// ET.ETTask<object>
	// ET.ETTask<uint>
	// ET.EntityRef<object>
	// ET.GetComponentSysSystem<object>
	// ET.IAwake<int,int>
	// ET.IAwake<int>
	// ET.IAwake<object,int>
	// ET.IAwake<object,object>
	// ET.IAwake<object>
	// ET.IAwakeSystem<int,int>
	// ET.IAwakeSystem<int>
	// ET.IAwakeSystem<object,int>
	// ET.IAwakeSystem<object,object>
	// ET.IAwakeSystem<object>
	// ET.ListComponent<Unity.Mathematics.float3>
	// ET.MultiMap<object,object>
	// ET.Singleton<object>
	// ET.StateMachineWrap<ET.Client.A2NetClient_MessageHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.A2NetClient_RequestHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.AI_AutoSkill.<Execute>d__1>
	// ET.StateMachineWrap<ET.Client.AI_AutoTask.<Execute>d__1>
	// ET.StateMachineWrap<ET.Client.AI_Stand.<Execute>d__1>
	// ET.StateMachineWrap<ET.Client.AI_XunLuo.<Execute>d__1>
	// ET.StateMachineWrap<ET.Client.AfterCreateClientScene_AddComponent.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.AfterCreateCurrentScene_AddComponent.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.AfterUnitCreate_CreateUnitView.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.AnimatorComponentSystem.<Play>d__3>
	// ET.StateMachineWrap<ET.Client.AppStartInitFinish_CreateLoginUI.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.BuffAdd_ClientHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.BuffRemove_ClientHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.BuffTick_ClientHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.BuffUpdate_ClientHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.C2M_GetAllItemsHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.CastBreak_ClientHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.CastFinish_ClientHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.CastHit_ClientHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.CastStart_ClientHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.ChangePosition_SyncGameObjectPos.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.ChangeRotation_SyncGameObjectRotation.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.ChooseServer_RefreshUI.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.ClientCastHelper.<CastSkill>d__0>
	// ET.StateMachineWrap<ET.Client.ClientSenderComponentSystem.<Call>d__6>
	// ET.StateMachineWrap<ET.Client.ClientSenderComponentSystem.<DisposeAsync>d__3>
	// ET.StateMachineWrap<ET.Client.ClientSenderComponentSystem.<LoginAsync>d__4>
	// ET.StateMachineWrap<ET.Client.ClientSenderComponentSystem.<RemoveFiberAsync>d__2>
	// ET.StateMachineWrap<ET.Client.EnterMapHelper.<EnterMapAsync>d__0>
	// ET.StateMachineWrap<ET.Client.EnterMap_ShowUIGroup.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.EntryEvent3_InitClient.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.Event.EnterMapFinish_RemoveUIChooseRole.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.FiberInit_NetClient.<Handle>d__0>
	// ET.StateMachineWrap<ET.Client.FxComponentSystem.<Spwan>d__2>
	// ET.StateMachineWrap<ET.Client.GetAllItems_RefreshUI.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.HttpClientHelper.<Get>d__0>
	// ET.StateMachineWrap<ET.Client.HttpClientHelper.<Post>d__1>
	// ET.StateMachineWrap<ET.Client.JoystickMove_RefreshMoveDirection.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.LoginFinish_CreateLobbyUI.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.LoginFinish_RemoveLoginUI.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.LoginHelper.<ChooseRole>d__4>
	// ET.StateMachineWrap<ET.Client.LoginHelper.<CreateRole>d__2>
	// ET.StateMachineWrap<ET.Client.LoginHelper.<DeleteRole>d__3>
	// ET.StateMachineWrap<ET.Client.LoginHelper.<GetRoleInfos>d__1>
	// ET.StateMachineWrap<ET.Client.LoginHelper.<Login>d__0>
	// ET.StateMachineWrap<ET.Client.M2C_BuffAddHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.M2C_BuffRemoveHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.M2C_BuffTickHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.M2C_BuffUpdateHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.M2C_CastBreakHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.M2C_CastFinishHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.M2C_CastHitHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.M2C_CastStartHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.M2C_CooldownChangeHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.M2C_CreateMyUnitHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.M2C_CreateUnitsHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.M2C_DamageResultHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.M2C_NumericChangeHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.M2C_PathfindingResultHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.M2C_RemoveUnitsHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.M2C_SetPositionHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.M2C_StartSceneChangeHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.M2C_StopHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.M2C_TreatResultHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.Main2NetClient_LoginHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.MapleComponentSystem.<GetServerList>d__3>
	// ET.StateMachineWrap<ET.Client.MapleComponentSystem.<PullServers>d__2>
	// ET.StateMachineWrap<ET.Client.MoveDelta_CharacterControllerMove.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.MoveHelper.<MoveToAsync>d__0>
	// ET.StateMachineWrap<ET.Client.MoveHelper.<MoveToAsync>d__1>
	// ET.StateMachineWrap<ET.Client.MoveStart_AnimatorComponentHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.MoveStop_AnimatorComponentHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.NetClient2Main_PingHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.NetClient2Main_SessionDisposeHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.NumericChanged_AnimatorComponentHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.OperaComponentSystem.<Test1>d__4>
	// ET.StateMachineWrap<ET.Client.OperaComponentSystem.<Test2>d__5>
	// ET.StateMachineWrap<ET.Client.PingComponentSystem.<PingAsync>d__2>
	// ET.StateMachineWrap<ET.Client.QualityComponentSystem.<LoadRemoteConfig>d__2>
	// ET.StateMachineWrap<ET.Client.QualityComponent_RemoteConfigLoadedHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.RemoteConfigComponentSystem.<GetRemoteConfig>d__1>
	// ET.StateMachineWrap<ET.Client.ResourcesLoaderComponentSystem.<LoadAllAssetsAsync>d__5<object>>
	// ET.StateMachineWrap<ET.Client.ResourcesLoaderComponentSystem.<LoadAssetAsync>d__3<object>>
	// ET.StateMachineWrap<ET.Client.ResourcesLoaderComponentSystem.<LoadAssetAsync>d__4>
	// ET.StateMachineWrap<ET.Client.ResourcesLoaderComponentSystem.<LoadSceneAsync>d__6>
	// ET.StateMachineWrap<ET.Client.RouterAddressComponentSystem.<GetAllRouter>d__2>
	// ET.StateMachineWrap<ET.Client.RouterAddressComponentSystem.<Init>d__1>
	// ET.StateMachineWrap<ET.Client.RouterAddressComponentSystem.<WaitTenMinGetAllRouter>d__3>
	// ET.StateMachineWrap<ET.Client.RouterCheckComponentSystem.<CheckAsync>d__1>
	// ET.StateMachineWrap<ET.Client.RouterHelper.<Connect>d__2>
	// ET.StateMachineWrap<ET.Client.RouterHelper.<CreateRouterSession>d__0>
	// ET.StateMachineWrap<ET.Client.RouterHelper.<GetRouterAddress>d__1>
	// ET.StateMachineWrap<ET.Client.SceneChangeHelper.<SceneChangeTo>d__0>
	// ET.StateMachineWrap<ET.Client.SceneChangeStart_AddComponent.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.SceneChangeStart_RemovePackage.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.SessionHelper.<Call>d__0>
	// ET.StateMachineWrap<ET.Client.SessionHelper.<Call>d__1<object>>
	// ET.StateMachineWrap<ET.Client.UIBagEventHandler.<OnCreate>d__0>
	// ET.StateMachineWrap<ET.Client.UIChatBigEventHandler.<OnCreate>d__0>
	// ET.StateMachineWrap<ET.Client.UIChatMiniEventHandler.<OnCreate>d__0>
	// ET.StateMachineWrap<ET.Client.UIChooseRoleEventHandler.<OnCreate>d__0>
	// ET.StateMachineWrap<ET.Client.UIChooseRoleLogicComponentSystem.<DeletaRoleClickEvent>d__4>
	// ET.StateMachineWrap<ET.Client.UIChooseRoleLogicComponentSystem.<ShowRoles>d__5>
	// ET.StateMachineWrap<ET.Client.UIComponentSystem.<CreatePanel>d__2>
	// ET.StateMachineWrap<ET.Client.UIComponentSystem.<HidePanel>d__4>
	// ET.StateMachineWrap<ET.Client.UIComponentSystem.<LoadUIObject>d__9>
	// ET.StateMachineWrap<ET.Client.UIComponentSystem.<RealHide>d__5>
	// ET.StateMachineWrap<ET.Client.UIComponentSystem.<RemovePanel>d__6>
	// ET.StateMachineWrap<ET.Client.UICreateRoleEventHandler.<OnCreate>d__0>
	// ET.StateMachineWrap<ET.Client.UICreateRoleLogicComponentSystem.<CreateRoleBtnEvent>d__4>
	// ET.StateMachineWrap<ET.Client.UIGroupComponentSystem.<OpenGroup>d__2>
	// ET.StateMachineWrap<ET.Client.UIGroupComponentSystem.<OpenGroupPanels>d__5>
	// ET.StateMachineWrap<ET.Client.UIHelper.<Create>d__0>
	// ET.StateMachineWrap<ET.Client.UIHelper.<Hide>d__2>
	// ET.StateMachineWrap<ET.Client.UIHelper.<OpenGroup>d__4>
	// ET.StateMachineWrap<ET.Client.UIHelper.<Remove>d__3>
	// ET.StateMachineWrap<ET.Client.UIJoystickEventHandler.<OnCreate>d__0>
	// ET.StateMachineWrap<ET.Client.UILoginEventHandler.<OnCreate>d__0>
	// ET.StateMachineWrap<ET.Client.UIMainEventHandler.<OnCreate>d__0>
	// ET.StateMachineWrap<ET.Client.UIPackageComponentSystem.<AddPackage>d__2>
	// ET.StateMachineWrap<ET.Client.UIPackageComponentSystem.<PackageLoad>d__9>
	// ET.StateMachineWrap<ET.Client.UIPing_ShowPing.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.UIServerListEventHandler.<OnCreate>d__0>
	// ET.StateMachineWrap<ET.Client.UIServerListLogicComponentSystem.<GetServerList>d__4>
	// ET.StateMachineWrap<ET.Client.UITweenComponentSystem.<PlayEnterTween>d__2>
	// ET.StateMachineWrap<ET.Client.UITweenComponentSystem.<PlayExistTween>d__3>
	// ET.StateMachineWrap<ET.ConsoleComponentSystem.<Start>d__1>
	// ET.StateMachineWrap<ET.Entry.<StartAsync>d__2>
	// ET.StateMachineWrap<ET.EntryEvent1_InitShare.<Run>d__0>
	// ET.StateMachineWrap<ET.FiberInit_Main.<Handle>d__0>
	// ET.StateMachineWrap<ET.MailBoxType_OrderedMessageHandler.<HandleInner>d__1>
	// ET.StateMachineWrap<ET.MailBoxType_UnOrderedMessageHandler.<HandleAsync>d__1>
	// ET.StateMachineWrap<ET.MessageHandler.<Handle>d__1<object,object,object>>
	// ET.StateMachineWrap<ET.MessageHandler.<Handle>d__1<object,object>>
	// ET.StateMachineWrap<ET.MessageSessionHandler.<HandleAsync>d__2<object,object>>
	// ET.StateMachineWrap<ET.MessageSessionHandler.<HandleAsync>d__2<object>>
	// ET.StateMachineWrap<ET.MoveComponentSystem.<MoveToAsync>d__5>
	// ET.StateMachineWrap<ET.NumericChangeEvent_NotifyWatcher.<Run>d__0>
	// ET.StateMachineWrap<ET.ObjectWaitSystem.<>c__DisplayClass5_0.<<Wait>g__WaitTimeout|0>d<object>>
	// ET.StateMachineWrap<ET.ObjectWaitSystem.<Wait>d__4<object>>
	// ET.StateMachineWrap<ET.ObjectWaitSystem.<Wait>d__5<object>>
	// ET.StateMachineWrap<ET.ReloadConfigConsoleHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.ReloadDllConsoleHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.RpcInfo.<Wait>d__7>
	// ET.StateMachineWrap<ET.SessionSystem.<>c__DisplayClass4_0.<<Call>g__Timeout|0>d>
	// ET.StateMachineWrap<ET.SessionSystem.<Call>d__3>
	// ET.StateMachineWrap<ET.SessionSystem.<Call>d__4>
	// ET.StructBsonSerialize<TrueSync.FP>
	// ET.StructBsonSerialize<TrueSync.TSQuaternion>
	// ET.StructBsonSerialize<TrueSync.TSVector2>
	// ET.StructBsonSerialize<TrueSync.TSVector4>
	// ET.StructBsonSerialize<TrueSync.TSVector>
	// ET.StructBsonSerialize<Unity.Mathematics.float2>
	// ET.StructBsonSerialize<Unity.Mathematics.float3>
	// ET.StructBsonSerialize<Unity.Mathematics.float4>
	// ET.StructBsonSerialize<Unity.Mathematics.quaternion>
	// ET.StructBsonSerialize<object>
	// ET.UpdateSystem<object>
	// MemoryPack.Formatters.ArrayFormatter<object>
	// MemoryPack.Formatters.DictionaryFormatter<int,long>
	// MemoryPack.Formatters.ListFormatter<Unity.Mathematics.float3>
	// MemoryPack.Formatters.ListFormatter<byte>
	// MemoryPack.Formatters.ListFormatter<int>
	// MemoryPack.Formatters.ListFormatter<long>
	// MemoryPack.Formatters.ListFormatter<object>
	// MemoryPack.IMemoryPackFormatter<Unity.Mathematics.float3>
	// MemoryPack.IMemoryPackFormatter<byte>
	// MemoryPack.IMemoryPackFormatter<int>
	// MemoryPack.IMemoryPackFormatter<long>
	// MemoryPack.IMemoryPackFormatter<object>
	// MemoryPack.IMemoryPackable<object>
	// MemoryPack.MemoryPackFormatter<System.UIntPtr>
	// MemoryPack.MemoryPackFormatter<object>
	// MongoDB.Bson.Serialization.IBsonSerializer<object>
	// MongoDB.Bson.Serialization.Serializers.SerializerBase<TrueSync.FP>
	// MongoDB.Bson.Serialization.Serializers.SerializerBase<TrueSync.TSQuaternion>
	// MongoDB.Bson.Serialization.Serializers.SerializerBase<TrueSync.TSVector2>
	// MongoDB.Bson.Serialization.Serializers.SerializerBase<TrueSync.TSVector4>
	// MongoDB.Bson.Serialization.Serializers.SerializerBase<TrueSync.TSVector>
	// MongoDB.Bson.Serialization.Serializers.SerializerBase<Unity.Mathematics.float2>
	// MongoDB.Bson.Serialization.Serializers.SerializerBase<Unity.Mathematics.float3>
	// MongoDB.Bson.Serialization.Serializers.SerializerBase<Unity.Mathematics.float4>
	// MongoDB.Bson.Serialization.Serializers.SerializerBase<Unity.Mathematics.quaternion>
	// MongoDB.Bson.Serialization.Serializers.SerializerBase<object>
	// MongoDB.Bson.Serialization.Serializers.StructSerializerBase<TrueSync.FP>
	// MongoDB.Bson.Serialization.Serializers.StructSerializerBase<TrueSync.TSQuaternion>
	// MongoDB.Bson.Serialization.Serializers.StructSerializerBase<TrueSync.TSVector2>
	// MongoDB.Bson.Serialization.Serializers.StructSerializerBase<TrueSync.TSVector4>
	// MongoDB.Bson.Serialization.Serializers.StructSerializerBase<TrueSync.TSVector>
	// MongoDB.Bson.Serialization.Serializers.StructSerializerBase<Unity.Mathematics.float2>
	// MongoDB.Bson.Serialization.Serializers.StructSerializerBase<Unity.Mathematics.float3>
	// MongoDB.Bson.Serialization.Serializers.StructSerializerBase<Unity.Mathematics.float4>
	// MongoDB.Bson.Serialization.Serializers.StructSerializerBase<Unity.Mathematics.quaternion>
	// MongoDB.Bson.Serialization.Serializers.StructSerializerBase<object>
	// System.Action<DotRecast.Detour.StraightPathItem>
	// System.Action<ET.MessageSessionDispatcherInfo>
	// System.Action<ET.NumericWatcherInfo>
	// System.Action<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Action<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Action<Unity.Mathematics.float3>
	// System.Action<byte>
	// System.Action<int>
	// System.Action<long,int>
	// System.Action<long,object>
	// System.Action<long>
	// System.Action<object,object>
	// System.Action<object>
	// System.ArraySegment.Enumerator<byte>
	// System.ArraySegment<byte>
	// System.ByReference<byte>
	// System.Collections.Concurrent.ConcurrentDictionary.<GetEnumerator>d__35<object,object>
	// System.Collections.Concurrent.ConcurrentDictionary.DictionaryEnumerator<object,object>
	// System.Collections.Concurrent.ConcurrentDictionary.Node<object,object>
	// System.Collections.Concurrent.ConcurrentDictionary.Tables<object,object>
	// System.Collections.Concurrent.ConcurrentDictionary<object,object>
	// System.Collections.Concurrent.ConcurrentQueue.<Enumerate>d__28<object>
	// System.Collections.Concurrent.ConcurrentQueue.Segment<object>
	// System.Collections.Concurrent.ConcurrentQueue<object>
	// System.Collections.Generic.ArraySortHelper<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.ArraySortHelper<ET.MessageSessionDispatcherInfo>
	// System.Collections.Generic.ArraySortHelper<ET.NumericWatcherInfo>
	// System.Collections.Generic.ArraySortHelper<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.ArraySortHelper<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.ArraySortHelper<Unity.Mathematics.float3>
	// System.Collections.Generic.ArraySortHelper<byte>
	// System.Collections.Generic.ArraySortHelper<int>
	// System.Collections.Generic.ArraySortHelper<long>
	// System.Collections.Generic.ArraySortHelper<object>
	// System.Collections.Generic.Comparer<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.Comparer<ET.ActorId>
	// System.Collections.Generic.Comparer<ET.MessageSessionDispatcherInfo>
	// System.Collections.Generic.Comparer<ET.NumericWatcherInfo>
	// System.Collections.Generic.Comparer<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.Comparer<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.Comparer<Unity.Mathematics.float3>
	// System.Collections.Generic.Comparer<byte>
	// System.Collections.Generic.Comparer<int>
	// System.Collections.Generic.Comparer<long>
	// System.Collections.Generic.Comparer<object>
	// System.Collections.Generic.Comparer<uint>
	// System.Collections.Generic.Comparer<ushort>
	// System.Collections.Generic.ComparisonComparer<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.ComparisonComparer<ET.ActorId>
	// System.Collections.Generic.ComparisonComparer<ET.MessageSessionDispatcherInfo>
	// System.Collections.Generic.ComparisonComparer<ET.NumericWatcherInfo>
	// System.Collections.Generic.ComparisonComparer<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.ComparisonComparer<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.ComparisonComparer<Unity.Mathematics.float3>
	// System.Collections.Generic.ComparisonComparer<byte>
	// System.Collections.Generic.ComparisonComparer<int>
	// System.Collections.Generic.ComparisonComparer<long>
	// System.Collections.Generic.ComparisonComparer<object>
	// System.Collections.Generic.ComparisonComparer<uint>
	// System.Collections.Generic.ComparisonComparer<ushort>
	// System.Collections.Generic.Dictionary.Enumerator<System.ValueTuple<int,int>,object>
	// System.Collections.Generic.Dictionary.Enumerator<int,ET.RpcInfo>
	// System.Collections.Generic.Dictionary.Enumerator<int,int>
	// System.Collections.Generic.Dictionary.Enumerator<int,long>
	// System.Collections.Generic.Dictionary.Enumerator<int,object>
	// System.Collections.Generic.Dictionary.Enumerator<long,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary.Enumerator<long,object>
	// System.Collections.Generic.Dictionary.Enumerator<object,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary.Enumerator<object,int>
	// System.Collections.Generic.Dictionary.Enumerator<object,object>
	// System.Collections.Generic.Dictionary.Enumerator<ushort,object>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<System.ValueTuple<int,int>,object>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<int,ET.RpcInfo>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<int,int>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<int,long>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<int,object>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<long,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<long,object>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<object,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<object,int>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<object,object>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<ushort,object>
	// System.Collections.Generic.Dictionary.KeyCollection<System.ValueTuple<int,int>,object>
	// System.Collections.Generic.Dictionary.KeyCollection<int,ET.RpcInfo>
	// System.Collections.Generic.Dictionary.KeyCollection<int,int>
	// System.Collections.Generic.Dictionary.KeyCollection<int,long>
	// System.Collections.Generic.Dictionary.KeyCollection<int,object>
	// System.Collections.Generic.Dictionary.KeyCollection<long,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary.KeyCollection<long,object>
	// System.Collections.Generic.Dictionary.KeyCollection<object,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary.KeyCollection<object,int>
	// System.Collections.Generic.Dictionary.KeyCollection<object,object>
	// System.Collections.Generic.Dictionary.KeyCollection<ushort,object>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<System.ValueTuple<int,int>,object>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<int,ET.RpcInfo>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<int,int>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<int,long>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<int,object>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<long,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<long,object>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<object,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<object,int>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<object,object>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<ushort,object>
	// System.Collections.Generic.Dictionary.ValueCollection<System.ValueTuple<int,int>,object>
	// System.Collections.Generic.Dictionary.ValueCollection<int,ET.RpcInfo>
	// System.Collections.Generic.Dictionary.ValueCollection<int,int>
	// System.Collections.Generic.Dictionary.ValueCollection<int,long>
	// System.Collections.Generic.Dictionary.ValueCollection<int,object>
	// System.Collections.Generic.Dictionary.ValueCollection<long,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary.ValueCollection<long,object>
	// System.Collections.Generic.Dictionary.ValueCollection<object,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary.ValueCollection<object,int>
	// System.Collections.Generic.Dictionary.ValueCollection<object,object>
	// System.Collections.Generic.Dictionary.ValueCollection<ushort,object>
	// System.Collections.Generic.Dictionary<System.ValueTuple<int,int>,object>
	// System.Collections.Generic.Dictionary<int,ET.RpcInfo>
	// System.Collections.Generic.Dictionary<int,int>
	// System.Collections.Generic.Dictionary<int,long>
	// System.Collections.Generic.Dictionary<int,object>
	// System.Collections.Generic.Dictionary<long,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary<long,object>
	// System.Collections.Generic.Dictionary<object,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary<object,int>
	// System.Collections.Generic.Dictionary<object,object>
	// System.Collections.Generic.Dictionary<ushort,object>
	// System.Collections.Generic.EqualityComparer<ET.ActorId>
	// System.Collections.Generic.EqualityComparer<ET.EntityRef<object>>
	// System.Collections.Generic.EqualityComparer<ET.RpcInfo>
	// System.Collections.Generic.EqualityComparer<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.EqualityComparer<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.EqualityComparer<System.ValueTuple<int,int>>
	// System.Collections.Generic.EqualityComparer<int>
	// System.Collections.Generic.EqualityComparer<long>
	// System.Collections.Generic.EqualityComparer<object>
	// System.Collections.Generic.EqualityComparer<uint>
	// System.Collections.Generic.EqualityComparer<ushort>
	// System.Collections.Generic.HashSet.Enumerator<object>
	// System.Collections.Generic.HashSet.Enumerator<ushort>
	// System.Collections.Generic.HashSet<object>
	// System.Collections.Generic.HashSet<ushort>
	// System.Collections.Generic.HashSetEqualityComparer<object>
	// System.Collections.Generic.HashSetEqualityComparer<ushort>
	// System.Collections.Generic.ICollection<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.ICollection<ET.MessageSessionDispatcherInfo>
	// System.Collections.Generic.ICollection<ET.NumericWatcherInfo>
	// System.Collections.Generic.ICollection<ET.RpcInfo>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.ValueTuple<int,int>,object>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<int,ET.RpcInfo>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<int,int>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<int,long>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<long,ET.EntityRef<object>>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<object,ET.EntityRef<object>>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<object,int>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<ushort,object>>
	// System.Collections.Generic.ICollection<Unity.Mathematics.float3>
	// System.Collections.Generic.ICollection<byte>
	// System.Collections.Generic.ICollection<int>
	// System.Collections.Generic.ICollection<long>
	// System.Collections.Generic.ICollection<object>
	// System.Collections.Generic.ICollection<ushort>
	// System.Collections.Generic.IComparer<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.IComparer<ET.MessageSessionDispatcherInfo>
	// System.Collections.Generic.IComparer<ET.NumericWatcherInfo>
	// System.Collections.Generic.IComparer<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.IComparer<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.IComparer<Unity.Mathematics.float3>
	// System.Collections.Generic.IComparer<byte>
	// System.Collections.Generic.IComparer<int>
	// System.Collections.Generic.IComparer<long>
	// System.Collections.Generic.IComparer<object>
	// System.Collections.Generic.IDictionary<object,object>
	// System.Collections.Generic.IEnumerable<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.IEnumerable<ET.MessageSessionDispatcherInfo>
	// System.Collections.Generic.IEnumerable<ET.NumericWatcherInfo>
	// System.Collections.Generic.IEnumerable<ET.RpcInfo>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<System.ValueTuple<int,int>,object>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<int,ET.RpcInfo>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<int,int>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<int,long>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<long,ET.EntityRef<object>>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,ET.EntityRef<object>>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,int>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<ushort,object>>
	// System.Collections.Generic.IEnumerable<Unity.Mathematics.float3>
	// System.Collections.Generic.IEnumerable<byte>
	// System.Collections.Generic.IEnumerable<int>
	// System.Collections.Generic.IEnumerable<long>
	// System.Collections.Generic.IEnumerable<object>
	// System.Collections.Generic.IEnumerable<ushort>
	// System.Collections.Generic.IEnumerator<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.IEnumerator<ET.MessageSessionDispatcherInfo>
	// System.Collections.Generic.IEnumerator<ET.NumericWatcherInfo>
	// System.Collections.Generic.IEnumerator<ET.RpcInfo>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<System.ValueTuple<int,int>,object>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<int,ET.RpcInfo>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<int,int>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<int,long>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<long,ET.EntityRef<object>>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<object,ET.EntityRef<object>>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<object,int>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<ushort,object>>
	// System.Collections.Generic.IEnumerator<Unity.Mathematics.float3>
	// System.Collections.Generic.IEnumerator<byte>
	// System.Collections.Generic.IEnumerator<int>
	// System.Collections.Generic.IEnumerator<long>
	// System.Collections.Generic.IEnumerator<object>
	// System.Collections.Generic.IEnumerator<ushort>
	// System.Collections.Generic.IEqualityComparer<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.IEqualityComparer<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.IEqualityComparer<System.ValueTuple<int,int>>
	// System.Collections.Generic.IEqualityComparer<int>
	// System.Collections.Generic.IEqualityComparer<long>
	// System.Collections.Generic.IEqualityComparer<object>
	// System.Collections.Generic.IEqualityComparer<ushort>
	// System.Collections.Generic.IList<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.IList<ET.MessageSessionDispatcherInfo>
	// System.Collections.Generic.IList<ET.NumericWatcherInfo>
	// System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.IList<Unity.Mathematics.float3>
	// System.Collections.Generic.IList<byte>
	// System.Collections.Generic.IList<int>
	// System.Collections.Generic.IList<long>
	// System.Collections.Generic.IList<object>
	// System.Collections.Generic.KeyValuePair<System.ValueTuple<int,int>,object>
	// System.Collections.Generic.KeyValuePair<int,ET.RpcInfo>
	// System.Collections.Generic.KeyValuePair<int,int>
	// System.Collections.Generic.KeyValuePair<int,long>
	// System.Collections.Generic.KeyValuePair<int,object>
	// System.Collections.Generic.KeyValuePair<long,ET.EntityRef<object>>
	// System.Collections.Generic.KeyValuePair<long,object>
	// System.Collections.Generic.KeyValuePair<object,ET.EntityRef<object>>
	// System.Collections.Generic.KeyValuePair<object,int>
	// System.Collections.Generic.KeyValuePair<object,object>
	// System.Collections.Generic.KeyValuePair<ushort,object>
	// System.Collections.Generic.List.Enumerator<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.List.Enumerator<ET.MessageSessionDispatcherInfo>
	// System.Collections.Generic.List.Enumerator<ET.NumericWatcherInfo>
	// System.Collections.Generic.List.Enumerator<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.List.Enumerator<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.List.Enumerator<Unity.Mathematics.float3>
	// System.Collections.Generic.List.Enumerator<byte>
	// System.Collections.Generic.List.Enumerator<int>
	// System.Collections.Generic.List.Enumerator<long>
	// System.Collections.Generic.List.Enumerator<object>
	// System.Collections.Generic.List<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.List<ET.MessageSessionDispatcherInfo>
	// System.Collections.Generic.List<ET.NumericWatcherInfo>
	// System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.List<Unity.Mathematics.float3>
	// System.Collections.Generic.List<byte>
	// System.Collections.Generic.List<int>
	// System.Collections.Generic.List<long>
	// System.Collections.Generic.List<object>
	// System.Collections.Generic.ObjectComparer<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.ObjectComparer<ET.ActorId>
	// System.Collections.Generic.ObjectComparer<ET.MessageSessionDispatcherInfo>
	// System.Collections.Generic.ObjectComparer<ET.NumericWatcherInfo>
	// System.Collections.Generic.ObjectComparer<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.ObjectComparer<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.ObjectComparer<Unity.Mathematics.float3>
	// System.Collections.Generic.ObjectComparer<byte>
	// System.Collections.Generic.ObjectComparer<int>
	// System.Collections.Generic.ObjectComparer<long>
	// System.Collections.Generic.ObjectComparer<object>
	// System.Collections.Generic.ObjectComparer<uint>
	// System.Collections.Generic.ObjectComparer<ushort>
	// System.Collections.Generic.ObjectEqualityComparer<ET.ActorId>
	// System.Collections.Generic.ObjectEqualityComparer<ET.EntityRef<object>>
	// System.Collections.Generic.ObjectEqualityComparer<ET.RpcInfo>
	// System.Collections.Generic.ObjectEqualityComparer<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.ObjectEqualityComparer<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.ObjectEqualityComparer<System.ValueTuple<int,int>>
	// System.Collections.Generic.ObjectEqualityComparer<int>
	// System.Collections.Generic.ObjectEqualityComparer<long>
	// System.Collections.Generic.ObjectEqualityComparer<object>
	// System.Collections.Generic.ObjectEqualityComparer<uint>
	// System.Collections.Generic.ObjectEqualityComparer<ushort>
	// System.Collections.Generic.Queue.Enumerator<object>
	// System.Collections.Generic.Queue<object>
	// System.Collections.Generic.SortedDictionary.<>c__DisplayClass34_0<long,object>
	// System.Collections.Generic.SortedDictionary.<>c__DisplayClass34_0<object,object>
	// System.Collections.Generic.SortedDictionary.<>c__DisplayClass34_1<long,object>
	// System.Collections.Generic.SortedDictionary.<>c__DisplayClass34_1<object,object>
	// System.Collections.Generic.SortedDictionary.Enumerator<long,object>
	// System.Collections.Generic.SortedDictionary.Enumerator<object,object>
	// System.Collections.Generic.SortedDictionary.KeyCollection.<>c__DisplayClass5_0<long,object>
	// System.Collections.Generic.SortedDictionary.KeyCollection.<>c__DisplayClass5_0<object,object>
	// System.Collections.Generic.SortedDictionary.KeyCollection.<>c__DisplayClass6_0<long,object>
	// System.Collections.Generic.SortedDictionary.KeyCollection.<>c__DisplayClass6_0<object,object>
	// System.Collections.Generic.SortedDictionary.KeyCollection.Enumerator<long,object>
	// System.Collections.Generic.SortedDictionary.KeyCollection.Enumerator<object,object>
	// System.Collections.Generic.SortedDictionary.KeyCollection<long,object>
	// System.Collections.Generic.SortedDictionary.KeyCollection<object,object>
	// System.Collections.Generic.SortedDictionary.KeyValuePairComparer<long,object>
	// System.Collections.Generic.SortedDictionary.KeyValuePairComparer<object,object>
	// System.Collections.Generic.SortedDictionary.ValueCollection.<>c__DisplayClass5_0<long,object>
	// System.Collections.Generic.SortedDictionary.ValueCollection.<>c__DisplayClass5_0<object,object>
	// System.Collections.Generic.SortedDictionary.ValueCollection.<>c__DisplayClass6_0<long,object>
	// System.Collections.Generic.SortedDictionary.ValueCollection.<>c__DisplayClass6_0<object,object>
	// System.Collections.Generic.SortedDictionary.ValueCollection.Enumerator<long,object>
	// System.Collections.Generic.SortedDictionary.ValueCollection.Enumerator<object,object>
	// System.Collections.Generic.SortedDictionary.ValueCollection<long,object>
	// System.Collections.Generic.SortedDictionary.ValueCollection<object,object>
	// System.Collections.Generic.SortedDictionary<long,object>
	// System.Collections.Generic.SortedDictionary<object,object>
	// System.Collections.Generic.SortedSet.<>c__DisplayClass52_0<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.SortedSet.<>c__DisplayClass52_0<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.SortedSet.<>c__DisplayClass53_0<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.SortedSet.<>c__DisplayClass53_0<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.SortedSet.<>c__DisplayClass85_0<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.SortedSet.<>c__DisplayClass85_0<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.SortedSet.<Reverse>d__94<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.SortedSet.<Reverse>d__94<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.SortedSet.Enumerator<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.SortedSet.Enumerator<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.SortedSet.Node<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.SortedSet.Node<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.SortedSet.TreeSubSet.<>c__DisplayClass9_0<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.SortedSet.TreeSubSet.<>c__DisplayClass9_0<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.SortedSet.TreeSubSet<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.SortedSet.TreeSubSet<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.SortedSet<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.SortedSet<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.SortedSetEqualityComparer<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.SortedSetEqualityComparer<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.Stack.Enumerator<object>
	// System.Collections.Generic.Stack<object>
	// System.Collections.Generic.TreeSet<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.TreeSet<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.TreeWalkPredicate<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.TreeWalkPredicate<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.ObjectModel.ReadOnlyCollection<DotRecast.Detour.StraightPathItem>
	// System.Collections.ObjectModel.ReadOnlyCollection<ET.MessageSessionDispatcherInfo>
	// System.Collections.ObjectModel.ReadOnlyCollection<ET.NumericWatcherInfo>
	// System.Collections.ObjectModel.ReadOnlyCollection<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.ObjectModel.ReadOnlyCollection<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.ObjectModel.ReadOnlyCollection<Unity.Mathematics.float3>
	// System.Collections.ObjectModel.ReadOnlyCollection<byte>
	// System.Collections.ObjectModel.ReadOnlyCollection<int>
	// System.Collections.ObjectModel.ReadOnlyCollection<long>
	// System.Collections.ObjectModel.ReadOnlyCollection<object>
	// System.Comparison<DotRecast.Detour.StraightPathItem>
	// System.Comparison<ET.ActorId>
	// System.Comparison<ET.MessageSessionDispatcherInfo>
	// System.Comparison<ET.NumericWatcherInfo>
	// System.Comparison<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Comparison<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Comparison<Unity.Mathematics.float3>
	// System.Comparison<byte>
	// System.Comparison<int>
	// System.Comparison<long>
	// System.Comparison<object>
	// System.Comparison<uint>
	// System.Comparison<ushort>
	// System.Func<int,byte>
	// System.Func<object,byte>
	// System.Func<object,object,object>
	// System.Func<object,object>
	// System.Func<object>
	// System.Linq.Buffer<ET.RpcInfo>
	// System.Linq.Buffer<object>
	// System.Linq.Enumerable.Iterator<int>
	// System.Linq.Enumerable.WhereArrayIterator<int>
	// System.Linq.Enumerable.WhereEnumerableIterator<int>
	// System.Linq.Enumerable.WhereListIterator<int>
	// System.Nullable<int>
	// System.Predicate<DotRecast.Detour.StraightPathItem>
	// System.Predicate<ET.MessageSessionDispatcherInfo>
	// System.Predicate<ET.NumericWatcherInfo>
	// System.Predicate<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Predicate<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Predicate<Unity.Mathematics.float3>
	// System.Predicate<byte>
	// System.Predicate<int>
	// System.Predicate<long>
	// System.Predicate<object>
	// System.Predicate<ushort>
	// System.ReadOnlySpan.Enumerator<byte>
	// System.ReadOnlySpan<byte>
	// System.Runtime.CompilerServices.ConditionalWeakTable.<>c<object,object>
	// System.Runtime.CompilerServices.ConditionalWeakTable.CreateValueCallback<object,object>
	// System.Runtime.CompilerServices.ConditionalWeakTable.Enumerator<object,object>
	// System.Runtime.CompilerServices.ConditionalWeakTable<object,object>
	// System.Runtime.CompilerServices.ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<object>
	// System.Runtime.CompilerServices.ConfiguredTaskAwaitable<object>
	// System.Runtime.CompilerServices.TaskAwaiter<object>
	// System.Span.Enumerator<byte>
	// System.Span<byte>
	// System.Threading.Tasks.ContinuationTaskFromResultTask<object>
	// System.Threading.Tasks.Task<object>
	// System.Threading.Tasks.TaskFactory.<>c<object>
	// System.Threading.Tasks.TaskFactory.<>c__DisplayClass32_0<object>
	// System.Threading.Tasks.TaskFactory.<>c__DisplayClass35_0<object>
	// System.Threading.Tasks.TaskFactory<object>
	// System.ValueTuple<ET.ActorId,object>
	// System.ValueTuple<int,int>
	// System.ValueTuple<long,long>
	// System.ValueTuple<uint,object>
	// System.ValueTuple<uint,uint>
	// System.ValueTuple<ushort,object>
	// }}

	public void RefMethods()
	{
		// object Cinemachine.CinemachineVirtualCamera.AddCinemachineComponent<object>()
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.A2NetClient_MessageHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.A2NetClient_MessageHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.AI_AutoSkill.<Execute>d__1>(ET.ETTaskCompleted&,ET.Client.AI_AutoSkill.<Execute>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.AfterCreateClientScene_AddComponent.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.AfterCreateClientScene_AddComponent.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.AfterCreateCurrentScene_AddComponent.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.AfterCreateCurrentScene_AddComponent.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.AfterUnitCreate_CreateUnitView.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.AfterUnitCreate_CreateUnitView.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.BuffUpdate_ClientHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.BuffUpdate_ClientHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.C2M_GetAllItemsHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.C2M_GetAllItemsHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.CastBreak_ClientHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.CastBreak_ClientHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.CastFinish_ClientHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.CastFinish_ClientHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.CastHit_ClientHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.CastHit_ClientHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.ChangePosition_SyncGameObjectPos.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.ChangePosition_SyncGameObjectPos.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.ChangeRotation_SyncGameObjectRotation.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.ChangeRotation_SyncGameObjectRotation.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.ChooseServer_RefreshUI.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.ChooseServer_RefreshUI.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.EnterMap_ShowUIGroup.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.EnterMap_ShowUIGroup.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.Event.EnterMapFinish_RemoveUIChooseRole.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.Event.EnterMapFinish_RemoveUIChooseRole.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.FiberInit_NetClient.<Handle>d__0>(ET.ETTaskCompleted&,ET.Client.FiberInit_NetClient.<Handle>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.GetAllItems_RefreshUI.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.GetAllItems_RefreshUI.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.JoystickMove_RefreshMoveDirection.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.JoystickMove_RefreshMoveDirection.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.LoginFinish_RemoveLoginUI.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.LoginFinish_RemoveLoginUI.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.M2C_BuffAddHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.M2C_BuffAddHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.M2C_BuffRemoveHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.M2C_BuffRemoveHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.M2C_BuffTickHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.M2C_BuffTickHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.M2C_BuffUpdateHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.M2C_BuffUpdateHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.M2C_CastBreakHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.M2C_CastBreakHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.M2C_CastFinishHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.M2C_CastFinishHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.M2C_CastHitHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.M2C_CastHitHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.M2C_CastStartHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.M2C_CastStartHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.M2C_CooldownChangeHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.M2C_CooldownChangeHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.M2C_CreateMyUnitHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.M2C_CreateMyUnitHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.M2C_CreateUnitsHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.M2C_CreateUnitsHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.M2C_DamageResultHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.M2C_DamageResultHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.M2C_NumericChangeHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.M2C_NumericChangeHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.M2C_PathfindingResultHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.M2C_PathfindingResultHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.M2C_RemoveUnitsHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.M2C_RemoveUnitsHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.M2C_SetPositionHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.M2C_SetPositionHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.M2C_StopHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.M2C_StopHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.M2C_TreatResultHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.M2C_TreatResultHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.MoveDelta_CharacterControllerMove.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.MoveDelta_CharacterControllerMove.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.MoveStart_AnimatorComponentHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.MoveStart_AnimatorComponentHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.MoveStop_AnimatorComponentHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.MoveStop_AnimatorComponentHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.NetClient2Main_PingHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.NetClient2Main_PingHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.NetClient2Main_SessionDisposeHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.NetClient2Main_SessionDisposeHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.NumericChanged_AnimatorComponentHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.NumericChanged_AnimatorComponentHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.SceneChangeStart_RemovePackage.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.SceneChangeStart_RemovePackage.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.UIPing_ShowPing.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.UIPing_ShowPing.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.UITweenComponentSystem.<PlayEnterTween>d__2>(ET.ETTaskCompleted&,ET.Client.UITweenComponentSystem.<PlayEnterTween>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.UITweenComponentSystem.<PlayExistTween>d__3>(ET.ETTaskCompleted&,ET.Client.UITweenComponentSystem.<PlayExistTween>d__3&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.EntryEvent1_InitShare.<Run>d__0>(ET.ETTaskCompleted&,ET.EntryEvent1_InitShare.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.NumericChangeEvent_NotifyWatcher.<Run>d__0>(ET.ETTaskCompleted&,ET.NumericChangeEvent_NotifyWatcher.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.ReloadConfigConsoleHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.ReloadConfigConsoleHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.ReloadDllConsoleHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.ReloadDllConsoleHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,ET.Client.ResourcesLoaderComponentSystem.<LoadSceneAsync>d__6>(System.Runtime.CompilerServices.TaskAwaiter&,ET.Client.ResourcesLoaderComponentSystem.<LoadSceneAsync>d__6&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,ET.ConsoleComponentSystem.<Start>d__1>(System.Runtime.CompilerServices.TaskAwaiter<object>&,ET.ConsoleComponentSystem.<Start>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.A2NetClient_RequestHandler.<Run>d__0>(object&,ET.Client.A2NetClient_RequestHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.AI_AutoTask.<Execute>d__1>(object&,ET.Client.AI_AutoTask.<Execute>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.AI_Stand.<Execute>d__1>(object&,ET.Client.AI_Stand.<Execute>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.AI_XunLuo.<Execute>d__1>(object&,ET.Client.AI_XunLuo.<Execute>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.AfterUnitCreate_CreateUnitView.<Run>d__0>(object&,ET.Client.AfterUnitCreate_CreateUnitView.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.AnimatorComponentSystem.<Play>d__3>(object&,ET.Client.AnimatorComponentSystem.<Play>d__3&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.AppStartInitFinish_CreateLoginUI.<Run>d__0>(object&,ET.Client.AppStartInitFinish_CreateLoginUI.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.BuffAdd_ClientHandler.<Run>d__0>(object&,ET.Client.BuffAdd_ClientHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.BuffRemove_ClientHandler.<Run>d__0>(object&,ET.Client.BuffRemove_ClientHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.BuffTick_ClientHandler.<Run>d__0>(object&,ET.Client.BuffTick_ClientHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.CastStart_ClientHandler.<Run>d__0>(object&,ET.Client.CastStart_ClientHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.ClientSenderComponentSystem.<DisposeAsync>d__3>(object&,ET.Client.ClientSenderComponentSystem.<DisposeAsync>d__3&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.ClientSenderComponentSystem.<RemoveFiberAsync>d__2>(object&,ET.Client.ClientSenderComponentSystem.<RemoveFiberAsync>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.EnterMapHelper.<EnterMapAsync>d__0>(object&,ET.Client.EnterMapHelper.<EnterMapAsync>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.EntryEvent3_InitClient.<Run>d__0>(object&,ET.Client.EntryEvent3_InitClient.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.LoginFinish_CreateLobbyUI.<Run>d__0>(object&,ET.Client.LoginFinish_CreateLobbyUI.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.LoginHelper.<Login>d__0>(object&,ET.Client.LoginHelper.<Login>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.M2C_StartSceneChangeHandler.<Run>d__0>(object&,ET.Client.M2C_StartSceneChangeHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.Main2NetClient_LoginHandler.<Run>d__0>(object&,ET.Client.Main2NetClient_LoginHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.MapleComponentSystem.<GetServerList>d__3>(object&,ET.Client.MapleComponentSystem.<GetServerList>d__3&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.MapleComponentSystem.<PullServers>d__2>(object&,ET.Client.MapleComponentSystem.<PullServers>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.MoveHelper.<MoveToAsync>d__1>(object&,ET.Client.MoveHelper.<MoveToAsync>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.OperaComponentSystem.<Test1>d__4>(object&,ET.Client.OperaComponentSystem.<Test1>d__4&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.OperaComponentSystem.<Test2>d__5>(object&,ET.Client.OperaComponentSystem.<Test2>d__5&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.PingComponentSystem.<PingAsync>d__2>(object&,ET.Client.PingComponentSystem.<PingAsync>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.QualityComponentSystem.<LoadRemoteConfig>d__2>(object&,ET.Client.QualityComponentSystem.<LoadRemoteConfig>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.QualityComponent_RemoteConfigLoadedHandler.<Run>d__0>(object&,ET.Client.QualityComponent_RemoteConfigLoadedHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.RemoteConfigComponentSystem.<GetRemoteConfig>d__1>(object&,ET.Client.RemoteConfigComponentSystem.<GetRemoteConfig>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.ResourcesLoaderComponentSystem.<LoadSceneAsync>d__6>(object&,ET.Client.ResourcesLoaderComponentSystem.<LoadSceneAsync>d__6&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.RouterAddressComponentSystem.<GetAllRouter>d__2>(object&,ET.Client.RouterAddressComponentSystem.<GetAllRouter>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.RouterAddressComponentSystem.<Init>d__1>(object&,ET.Client.RouterAddressComponentSystem.<Init>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.RouterAddressComponentSystem.<WaitTenMinGetAllRouter>d__3>(object&,ET.Client.RouterAddressComponentSystem.<WaitTenMinGetAllRouter>d__3&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.RouterCheckComponentSystem.<CheckAsync>d__1>(object&,ET.Client.RouterCheckComponentSystem.<CheckAsync>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.SceneChangeHelper.<SceneChangeTo>d__0>(object&,ET.Client.SceneChangeHelper.<SceneChangeTo>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.SceneChangeStart_AddComponent.<Run>d__0>(object&,ET.Client.SceneChangeStart_AddComponent.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.SessionHelper.<Call>d__0>(object&,ET.Client.SessionHelper.<Call>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.UIChooseRoleLogicComponentSystem.<DeletaRoleClickEvent>d__4>(object&,ET.Client.UIChooseRoleLogicComponentSystem.<DeletaRoleClickEvent>d__4&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.UIChooseRoleLogicComponentSystem.<ShowRoles>d__5>(object&,ET.Client.UIChooseRoleLogicComponentSystem.<ShowRoles>d__5&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.UIComponentSystem.<CreatePanel>d__2>(object&,ET.Client.UIComponentSystem.<CreatePanel>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.UIComponentSystem.<HidePanel>d__4>(object&,ET.Client.UIComponentSystem.<HidePanel>d__4&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.UIComponentSystem.<RealHide>d__5>(object&,ET.Client.UIComponentSystem.<RealHide>d__5&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.UIComponentSystem.<RemovePanel>d__6>(object&,ET.Client.UIComponentSystem.<RemovePanel>d__6&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.UICreateRoleLogicComponentSystem.<CreateRoleBtnEvent>d__4>(object&,ET.Client.UICreateRoleLogicComponentSystem.<CreateRoleBtnEvent>d__4&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.UIGroupComponentSystem.<OpenGroup>d__2>(object&,ET.Client.UIGroupComponentSystem.<OpenGroup>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.UIGroupComponentSystem.<OpenGroupPanels>d__5>(object&,ET.Client.UIGroupComponentSystem.<OpenGroupPanels>d__5&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.UIHelper.<Create>d__0>(object&,ET.Client.UIHelper.<Create>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.UIHelper.<Hide>d__2>(object&,ET.Client.UIHelper.<Hide>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.UIHelper.<OpenGroup>d__4>(object&,ET.Client.UIHelper.<OpenGroup>d__4&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.UIHelper.<Remove>d__3>(object&,ET.Client.UIHelper.<Remove>d__3&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.UIPackageComponentSystem.<AddPackage>d__2>(object&,ET.Client.UIPackageComponentSystem.<AddPackage>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.UIPackageComponentSystem.<PackageLoad>d__9>(object&,ET.Client.UIPackageComponentSystem.<PackageLoad>d__9&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.UIServerListLogicComponentSystem.<GetServerList>d__4>(object&,ET.Client.UIServerListLogicComponentSystem.<GetServerList>d__4&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.ConsoleComponentSystem.<Start>d__1>(object&,ET.ConsoleComponentSystem.<Start>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Entry.<StartAsync>d__2>(object&,ET.Entry.<StartAsync>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.FiberInit_Main.<Handle>d__0>(object&,ET.FiberInit_Main.<Handle>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.MailBoxType_OrderedMessageHandler.<HandleInner>d__1>(object&,ET.MailBoxType_OrderedMessageHandler.<HandleInner>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.MailBoxType_UnOrderedMessageHandler.<HandleAsync>d__1>(object&,ET.MailBoxType_UnOrderedMessageHandler.<HandleAsync>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.MessageHandler.<Handle>d__1<object,object,object>>(object&,ET.MessageHandler.<Handle>d__1<object,object,object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.MessageHandler.<Handle>d__1<object,object>>(object&,ET.MessageHandler.<Handle>d__1<object,object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.MessageSessionHandler.<HandleAsync>d__2<object,object>>(object&,ET.MessageSessionHandler.<HandleAsync>d__2<object,object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.MessageSessionHandler.<HandleAsync>d__2<object>>(object&,ET.MessageSessionHandler.<HandleAsync>d__2<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.ObjectWaitSystem.<>c__DisplayClass5_0.<<Wait>g__WaitTimeout|0>d<object>>(object&,ET.ObjectWaitSystem.<>c__DisplayClass5_0.<<Wait>g__WaitTimeout|0>d<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.ReloadConfigConsoleHandler.<Run>d__0>(object&,ET.ReloadConfigConsoleHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.SessionSystem.<>c__DisplayClass4_0.<<Call>g__Timeout|0>d>(object&,ET.SessionSystem.<>c__DisplayClass4_0.<<Call>g__Timeout|0>d&)
		// System.Void ET.ETAsyncTaskMethodBuilder<System.ValueTuple<long,long>>.AwaitUnsafeOnCompleted<object,ET.Client.ClientSenderComponentSystem.<LoginAsync>d__4>(object&,ET.Client.ClientSenderComponentSystem.<LoginAsync>d__4&)
		// System.Void ET.ETAsyncTaskMethodBuilder<System.ValueTuple<uint,object>>.AwaitUnsafeOnCompleted<object,ET.Client.RouterHelper.<GetRouterAddress>d__1>(object&,ET.Client.RouterHelper.<GetRouterAddress>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.AwaitUnsafeOnCompleted<object,ET.MoveComponentSystem.<MoveToAsync>d__5>(object&,ET.MoveComponentSystem.<MoveToAsync>d__5&)
		// System.Void ET.ETAsyncTaskMethodBuilder<int>.AwaitUnsafeOnCompleted<object,ET.Client.ClientCastHelper.<CastSkill>d__0>(object&,ET.Client.ClientCastHelper.<CastSkill>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<int>.AwaitUnsafeOnCompleted<object,ET.Client.LoginHelper.<ChooseRole>d__4>(object&,ET.Client.LoginHelper.<ChooseRole>d__4&)
		// System.Void ET.ETAsyncTaskMethodBuilder<int>.AwaitUnsafeOnCompleted<object,ET.Client.LoginHelper.<CreateRole>d__2>(object&,ET.Client.LoginHelper.<CreateRole>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder<int>.AwaitUnsafeOnCompleted<object,ET.Client.LoginHelper.<DeleteRole>d__3>(object&,ET.Client.LoginHelper.<DeleteRole>d__3&)
		// System.Void ET.ETAsyncTaskMethodBuilder<int>.AwaitUnsafeOnCompleted<object,ET.Client.LoginHelper.<GetRoleInfos>d__1>(object&,ET.Client.LoginHelper.<GetRoleInfos>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder<int>.AwaitUnsafeOnCompleted<object,ET.Client.MoveHelper.<MoveToAsync>d__0>(object&,ET.Client.MoveHelper.<MoveToAsync>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,ET.Client.ResourcesLoaderComponentSystem.<LoadAllAssetsAsync>d__5<object>>(System.Runtime.CompilerServices.TaskAwaiter&,ET.Client.ResourcesLoaderComponentSystem.<LoadAllAssetsAsync>d__5<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,ET.Client.ResourcesLoaderComponentSystem.<LoadAssetAsync>d__3<object>>(System.Runtime.CompilerServices.TaskAwaiter&,ET.Client.ResourcesLoaderComponentSystem.<LoadAssetAsync>d__3<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,ET.Client.ResourcesLoaderComponentSystem.<LoadAssetAsync>d__4>(System.Runtime.CompilerServices.TaskAwaiter&,ET.Client.ResourcesLoaderComponentSystem.<LoadAssetAsync>d__4&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,ET.Client.HttpClientHelper.<Get>d__0>(System.Runtime.CompilerServices.TaskAwaiter<object>&,ET.Client.HttpClientHelper.<Get>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,ET.Client.HttpClientHelper.<Post>d__1>(System.Runtime.CompilerServices.TaskAwaiter<object>&,ET.Client.HttpClientHelper.<Post>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.ClientSenderComponentSystem.<Call>d__6>(object&,ET.Client.ClientSenderComponentSystem.<Call>d__6&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.FxComponentSystem.<Spwan>d__2>(object&,ET.Client.FxComponentSystem.<Spwan>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.ResourcesLoaderComponentSystem.<LoadAllAssetsAsync>d__5<object>>(object&,ET.Client.ResourcesLoaderComponentSystem.<LoadAllAssetsAsync>d__5<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.ResourcesLoaderComponentSystem.<LoadAssetAsync>d__3<object>>(object&,ET.Client.ResourcesLoaderComponentSystem.<LoadAssetAsync>d__3<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.ResourcesLoaderComponentSystem.<LoadAssetAsync>d__4>(object&,ET.Client.ResourcesLoaderComponentSystem.<LoadAssetAsync>d__4&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.RouterHelper.<CreateRouterSession>d__0>(object&,ET.Client.RouterHelper.<CreateRouterSession>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.SessionHelper.<Call>d__1<object>>(object&,ET.Client.SessionHelper.<Call>d__1<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.UIBagEventHandler.<OnCreate>d__0>(object&,ET.Client.UIBagEventHandler.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.UIChatBigEventHandler.<OnCreate>d__0>(object&,ET.Client.UIChatBigEventHandler.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.UIChatMiniEventHandler.<OnCreate>d__0>(object&,ET.Client.UIChatMiniEventHandler.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.UIChooseRoleEventHandler.<OnCreate>d__0>(object&,ET.Client.UIChooseRoleEventHandler.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.UIComponentSystem.<LoadUIObject>d__9>(object&,ET.Client.UIComponentSystem.<LoadUIObject>d__9&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.UICreateRoleEventHandler.<OnCreate>d__0>(object&,ET.Client.UICreateRoleEventHandler.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.UIJoystickEventHandler.<OnCreate>d__0>(object&,ET.Client.UIJoystickEventHandler.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.UILoginEventHandler.<OnCreate>d__0>(object&,ET.Client.UILoginEventHandler.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.UIMainEventHandler.<OnCreate>d__0>(object&,ET.Client.UIMainEventHandler.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.UIServerListEventHandler.<OnCreate>d__0>(object&,ET.Client.UIServerListEventHandler.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.ObjectWaitSystem.<Wait>d__4<object>>(object&,ET.ObjectWaitSystem.<Wait>d__4<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.ObjectWaitSystem.<Wait>d__5<object>>(object&,ET.ObjectWaitSystem.<Wait>d__5<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.RpcInfo.<Wait>d__7>(object&,ET.RpcInfo.<Wait>d__7&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.SessionSystem.<Call>d__3>(object&,ET.SessionSystem.<Call>d__3&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.SessionSystem.<Call>d__4>(object&,ET.SessionSystem.<Call>d__4&)
		// System.Void ET.ETAsyncTaskMethodBuilder<uint>.AwaitUnsafeOnCompleted<object,ET.Client.RouterHelper.<Connect>d__2>(object&,ET.Client.RouterHelper.<Connect>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.A2NetClient_MessageHandler.<Run>d__0>(ET.Client.A2NetClient_MessageHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.A2NetClient_RequestHandler.<Run>d__0>(ET.Client.A2NetClient_RequestHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.AI_AutoSkill.<Execute>d__1>(ET.Client.AI_AutoSkill.<Execute>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.AI_AutoTask.<Execute>d__1>(ET.Client.AI_AutoTask.<Execute>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.AI_Stand.<Execute>d__1>(ET.Client.AI_Stand.<Execute>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.AI_XunLuo.<Execute>d__1>(ET.Client.AI_XunLuo.<Execute>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.AfterCreateClientScene_AddComponent.<Run>d__0>(ET.Client.AfterCreateClientScene_AddComponent.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.AfterCreateCurrentScene_AddComponent.<Run>d__0>(ET.Client.AfterCreateCurrentScene_AddComponent.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.AfterUnitCreate_CreateUnitView.<Run>d__0>(ET.Client.AfterUnitCreate_CreateUnitView.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.AnimatorComponentSystem.<Play>d__3>(ET.Client.AnimatorComponentSystem.<Play>d__3&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.AppStartInitFinish_CreateLoginUI.<Run>d__0>(ET.Client.AppStartInitFinish_CreateLoginUI.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.BuffAdd_ClientHandler.<Run>d__0>(ET.Client.BuffAdd_ClientHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.BuffRemove_ClientHandler.<Run>d__0>(ET.Client.BuffRemove_ClientHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.BuffTick_ClientHandler.<Run>d__0>(ET.Client.BuffTick_ClientHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.BuffUpdate_ClientHandler.<Run>d__0>(ET.Client.BuffUpdate_ClientHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.C2M_GetAllItemsHandler.<Run>d__0>(ET.Client.C2M_GetAllItemsHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.CastBreak_ClientHandler.<Run>d__0>(ET.Client.CastBreak_ClientHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.CastFinish_ClientHandler.<Run>d__0>(ET.Client.CastFinish_ClientHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.CastHit_ClientHandler.<Run>d__0>(ET.Client.CastHit_ClientHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.CastStart_ClientHandler.<Run>d__0>(ET.Client.CastStart_ClientHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.ChangePosition_SyncGameObjectPos.<Run>d__0>(ET.Client.ChangePosition_SyncGameObjectPos.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.ChangeRotation_SyncGameObjectRotation.<Run>d__0>(ET.Client.ChangeRotation_SyncGameObjectRotation.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.ChooseServer_RefreshUI.<Run>d__0>(ET.Client.ChooseServer_RefreshUI.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.ClientSenderComponentSystem.<DisposeAsync>d__3>(ET.Client.ClientSenderComponentSystem.<DisposeAsync>d__3&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.ClientSenderComponentSystem.<RemoveFiberAsync>d__2>(ET.Client.ClientSenderComponentSystem.<RemoveFiberAsync>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.EnterMapHelper.<EnterMapAsync>d__0>(ET.Client.EnterMapHelper.<EnterMapAsync>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.EnterMap_ShowUIGroup.<Run>d__0>(ET.Client.EnterMap_ShowUIGroup.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.EntryEvent3_InitClient.<Run>d__0>(ET.Client.EntryEvent3_InitClient.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.Event.EnterMapFinish_RemoveUIChooseRole.<Run>d__0>(ET.Client.Event.EnterMapFinish_RemoveUIChooseRole.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.FiberInit_NetClient.<Handle>d__0>(ET.Client.FiberInit_NetClient.<Handle>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.GetAllItems_RefreshUI.<Run>d__0>(ET.Client.GetAllItems_RefreshUI.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.JoystickMove_RefreshMoveDirection.<Run>d__0>(ET.Client.JoystickMove_RefreshMoveDirection.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.LoginFinish_CreateLobbyUI.<Run>d__0>(ET.Client.LoginFinish_CreateLobbyUI.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.LoginFinish_RemoveLoginUI.<Run>d__0>(ET.Client.LoginFinish_RemoveLoginUI.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.LoginHelper.<Login>d__0>(ET.Client.LoginHelper.<Login>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.M2C_BuffAddHandler.<Run>d__0>(ET.Client.M2C_BuffAddHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.M2C_BuffRemoveHandler.<Run>d__0>(ET.Client.M2C_BuffRemoveHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.M2C_BuffTickHandler.<Run>d__0>(ET.Client.M2C_BuffTickHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.M2C_BuffUpdateHandler.<Run>d__0>(ET.Client.M2C_BuffUpdateHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.M2C_CastBreakHandler.<Run>d__0>(ET.Client.M2C_CastBreakHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.M2C_CastFinishHandler.<Run>d__0>(ET.Client.M2C_CastFinishHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.M2C_CastHitHandler.<Run>d__0>(ET.Client.M2C_CastHitHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.M2C_CastStartHandler.<Run>d__0>(ET.Client.M2C_CastStartHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.M2C_CooldownChangeHandler.<Run>d__0>(ET.Client.M2C_CooldownChangeHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.M2C_CreateMyUnitHandler.<Run>d__0>(ET.Client.M2C_CreateMyUnitHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.M2C_CreateUnitsHandler.<Run>d__0>(ET.Client.M2C_CreateUnitsHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.M2C_DamageResultHandler.<Run>d__0>(ET.Client.M2C_DamageResultHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.M2C_NumericChangeHandler.<Run>d__0>(ET.Client.M2C_NumericChangeHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.M2C_PathfindingResultHandler.<Run>d__0>(ET.Client.M2C_PathfindingResultHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.M2C_RemoveUnitsHandler.<Run>d__0>(ET.Client.M2C_RemoveUnitsHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.M2C_SetPositionHandler.<Run>d__0>(ET.Client.M2C_SetPositionHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.M2C_StartSceneChangeHandler.<Run>d__0>(ET.Client.M2C_StartSceneChangeHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.M2C_StopHandler.<Run>d__0>(ET.Client.M2C_StopHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.M2C_TreatResultHandler.<Run>d__0>(ET.Client.M2C_TreatResultHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.Main2NetClient_LoginHandler.<Run>d__0>(ET.Client.Main2NetClient_LoginHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.MapleComponentSystem.<GetServerList>d__3>(ET.Client.MapleComponentSystem.<GetServerList>d__3&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.MapleComponentSystem.<PullServers>d__2>(ET.Client.MapleComponentSystem.<PullServers>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.MoveDelta_CharacterControllerMove.<Run>d__0>(ET.Client.MoveDelta_CharacterControllerMove.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.MoveHelper.<MoveToAsync>d__1>(ET.Client.MoveHelper.<MoveToAsync>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.MoveStart_AnimatorComponentHandler.<Run>d__0>(ET.Client.MoveStart_AnimatorComponentHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.MoveStop_AnimatorComponentHandler.<Run>d__0>(ET.Client.MoveStop_AnimatorComponentHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.NetClient2Main_PingHandler.<Run>d__0>(ET.Client.NetClient2Main_PingHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.NetClient2Main_SessionDisposeHandler.<Run>d__0>(ET.Client.NetClient2Main_SessionDisposeHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.NumericChanged_AnimatorComponentHandler.<Run>d__0>(ET.Client.NumericChanged_AnimatorComponentHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.OperaComponentSystem.<Test1>d__4>(ET.Client.OperaComponentSystem.<Test1>d__4&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.OperaComponentSystem.<Test2>d__5>(ET.Client.OperaComponentSystem.<Test2>d__5&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.PingComponentSystem.<PingAsync>d__2>(ET.Client.PingComponentSystem.<PingAsync>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.QualityComponentSystem.<LoadRemoteConfig>d__2>(ET.Client.QualityComponentSystem.<LoadRemoteConfig>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.QualityComponent_RemoteConfigLoadedHandler.<Run>d__0>(ET.Client.QualityComponent_RemoteConfigLoadedHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.RemoteConfigComponentSystem.<GetRemoteConfig>d__1>(ET.Client.RemoteConfigComponentSystem.<GetRemoteConfig>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.ResourcesLoaderComponentSystem.<LoadSceneAsync>d__6>(ET.Client.ResourcesLoaderComponentSystem.<LoadSceneAsync>d__6&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.RouterAddressComponentSystem.<GetAllRouter>d__2>(ET.Client.RouterAddressComponentSystem.<GetAllRouter>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.RouterAddressComponentSystem.<Init>d__1>(ET.Client.RouterAddressComponentSystem.<Init>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.RouterAddressComponentSystem.<WaitTenMinGetAllRouter>d__3>(ET.Client.RouterAddressComponentSystem.<WaitTenMinGetAllRouter>d__3&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.RouterCheckComponentSystem.<CheckAsync>d__1>(ET.Client.RouterCheckComponentSystem.<CheckAsync>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.SceneChangeHelper.<SceneChangeTo>d__0>(ET.Client.SceneChangeHelper.<SceneChangeTo>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.SceneChangeStart_AddComponent.<Run>d__0>(ET.Client.SceneChangeStart_AddComponent.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.SceneChangeStart_RemovePackage.<Run>d__0>(ET.Client.SceneChangeStart_RemovePackage.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.SessionHelper.<Call>d__0>(ET.Client.SessionHelper.<Call>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.UIChooseRoleLogicComponentSystem.<DeletaRoleClickEvent>d__4>(ET.Client.UIChooseRoleLogicComponentSystem.<DeletaRoleClickEvent>d__4&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.UIChooseRoleLogicComponentSystem.<ShowRoles>d__5>(ET.Client.UIChooseRoleLogicComponentSystem.<ShowRoles>d__5&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.UIComponentSystem.<CreatePanel>d__2>(ET.Client.UIComponentSystem.<CreatePanel>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.UIComponentSystem.<HidePanel>d__4>(ET.Client.UIComponentSystem.<HidePanel>d__4&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.UIComponentSystem.<RealHide>d__5>(ET.Client.UIComponentSystem.<RealHide>d__5&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.UIComponentSystem.<RemovePanel>d__6>(ET.Client.UIComponentSystem.<RemovePanel>d__6&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.UICreateRoleLogicComponentSystem.<CreateRoleBtnEvent>d__4>(ET.Client.UICreateRoleLogicComponentSystem.<CreateRoleBtnEvent>d__4&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.UIGroupComponentSystem.<OpenGroup>d__2>(ET.Client.UIGroupComponentSystem.<OpenGroup>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.UIGroupComponentSystem.<OpenGroupPanels>d__5>(ET.Client.UIGroupComponentSystem.<OpenGroupPanels>d__5&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.UIHelper.<Create>d__0>(ET.Client.UIHelper.<Create>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.UIHelper.<Hide>d__2>(ET.Client.UIHelper.<Hide>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.UIHelper.<OpenGroup>d__4>(ET.Client.UIHelper.<OpenGroup>d__4&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.UIHelper.<Remove>d__3>(ET.Client.UIHelper.<Remove>d__3&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.UIPackageComponentSystem.<AddPackage>d__2>(ET.Client.UIPackageComponentSystem.<AddPackage>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.UIPackageComponentSystem.<PackageLoad>d__9>(ET.Client.UIPackageComponentSystem.<PackageLoad>d__9&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.UIPing_ShowPing.<Run>d__0>(ET.Client.UIPing_ShowPing.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.UIServerListLogicComponentSystem.<GetServerList>d__4>(ET.Client.UIServerListLogicComponentSystem.<GetServerList>d__4&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.UITweenComponentSystem.<PlayEnterTween>d__2>(ET.Client.UITweenComponentSystem.<PlayEnterTween>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.UITweenComponentSystem.<PlayExistTween>d__3>(ET.Client.UITweenComponentSystem.<PlayExistTween>d__3&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.ConsoleComponentSystem.<Start>d__1>(ET.ConsoleComponentSystem.<Start>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Entry.<StartAsync>d__2>(ET.Entry.<StartAsync>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.EntryEvent1_InitShare.<Run>d__0>(ET.EntryEvent1_InitShare.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.EventSystem.<PublishAsync>d__4<object,ET.Client.AppStartInitFinish>>(ET.EventSystem.<PublishAsync>d__4<object,ET.Client.AppStartInitFinish>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.EventSystem.<PublishAsync>d__4<object,ET.Client.LoginFinish>>(ET.EventSystem.<PublishAsync>d__4<object,ET.Client.LoginFinish>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.EventSystem.<PublishAsync>d__4<object,ET.Client.RemoteConfigLoaded>>(ET.EventSystem.<PublishAsync>d__4<object,ET.Client.RemoteConfigLoaded>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.EventSystem.<PublishAsync>d__4<object,ET.EntryEvent1>>(ET.EventSystem.<PublishAsync>d__4<object,ET.EntryEvent1>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.EventSystem.<PublishAsync>d__4<object,ET.EntryEvent2>>(ET.EventSystem.<PublishAsync>d__4<object,ET.EntryEvent2>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.EventSystem.<PublishAsync>d__4<object,ET.EntryEvent3>>(ET.EventSystem.<PublishAsync>d__4<object,ET.EntryEvent3>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.FiberInit_Main.<Handle>d__0>(ET.FiberInit_Main.<Handle>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.MailBoxType_OrderedMessageHandler.<HandleInner>d__1>(ET.MailBoxType_OrderedMessageHandler.<HandleInner>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.MailBoxType_UnOrderedMessageHandler.<HandleAsync>d__1>(ET.MailBoxType_UnOrderedMessageHandler.<HandleAsync>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.MessageHandler.<Handle>d__1<object,object,object>>(ET.MessageHandler.<Handle>d__1<object,object,object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.MessageHandler.<Handle>d__1<object,object>>(ET.MessageHandler.<Handle>d__1<object,object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.MessageSessionHandler.<HandleAsync>d__2<object,object>>(ET.MessageSessionHandler.<HandleAsync>d__2<object,object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.MessageSessionHandler.<HandleAsync>d__2<object>>(ET.MessageSessionHandler.<HandleAsync>d__2<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.NumericChangeEvent_NotifyWatcher.<Run>d__0>(ET.NumericChangeEvent_NotifyWatcher.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.ObjectWaitSystem.<>c__DisplayClass5_0.<<Wait>g__WaitTimeout|0>d<object>>(ET.ObjectWaitSystem.<>c__DisplayClass5_0.<<Wait>g__WaitTimeout|0>d<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.ReloadConfigConsoleHandler.<Run>d__0>(ET.ReloadConfigConsoleHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.ReloadDllConsoleHandler.<Run>d__0>(ET.ReloadDllConsoleHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.SessionSystem.<>c__DisplayClass4_0.<<Call>g__Timeout|0>d>(ET.SessionSystem.<>c__DisplayClass4_0.<<Call>g__Timeout|0>d&)
		// System.Void ET.ETAsyncTaskMethodBuilder<ET.Client.Wait_CreateMyUnit>.Start<ET.ObjectWaitSystem.<Wait>d__4<ET.Client.Wait_CreateMyUnit>>(ET.ObjectWaitSystem.<Wait>d__4<ET.Client.Wait_CreateMyUnit>&)
		// System.Void ET.ETAsyncTaskMethodBuilder<ET.Client.Wait_SceneChangeFinish>.Start<ET.ObjectWaitSystem.<Wait>d__4<ET.Client.Wait_SceneChangeFinish>>(ET.ObjectWaitSystem.<Wait>d__4<ET.Client.Wait_SceneChangeFinish>&)
		// System.Void ET.ETAsyncTaskMethodBuilder<ET.Client.Wait_UnitStop>.Start<ET.ObjectWaitSystem.<Wait>d__4<ET.Client.Wait_UnitStop>>(ET.ObjectWaitSystem.<Wait>d__4<ET.Client.Wait_UnitStop>&)
		// System.Void ET.ETAsyncTaskMethodBuilder<System.ValueTuple<long,long>>.Start<ET.Client.ClientSenderComponentSystem.<LoginAsync>d__4>(ET.Client.ClientSenderComponentSystem.<LoginAsync>d__4&)
		// System.Void ET.ETAsyncTaskMethodBuilder<System.ValueTuple<uint,object>>.Start<ET.Client.RouterHelper.<GetRouterAddress>d__1>(ET.Client.RouterHelper.<GetRouterAddress>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.Start<ET.MoveComponentSystem.<MoveToAsync>d__5>(ET.MoveComponentSystem.<MoveToAsync>d__5&)
		// System.Void ET.ETAsyncTaskMethodBuilder<int>.Start<ET.Client.ClientCastHelper.<CastSkill>d__0>(ET.Client.ClientCastHelper.<CastSkill>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<int>.Start<ET.Client.LoginHelper.<ChooseRole>d__4>(ET.Client.LoginHelper.<ChooseRole>d__4&)
		// System.Void ET.ETAsyncTaskMethodBuilder<int>.Start<ET.Client.LoginHelper.<CreateRole>d__2>(ET.Client.LoginHelper.<CreateRole>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder<int>.Start<ET.Client.LoginHelper.<DeleteRole>d__3>(ET.Client.LoginHelper.<DeleteRole>d__3&)
		// System.Void ET.ETAsyncTaskMethodBuilder<int>.Start<ET.Client.LoginHelper.<GetRoleInfos>d__1>(ET.Client.LoginHelper.<GetRoleInfos>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder<int>.Start<ET.Client.MoveHelper.<MoveToAsync>d__0>(ET.Client.MoveHelper.<MoveToAsync>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.ClientSenderComponentSystem.<Call>d__6>(ET.Client.ClientSenderComponentSystem.<Call>d__6&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.FxComponentSystem.<Spwan>d__2>(ET.Client.FxComponentSystem.<Spwan>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.HttpClientHelper.<Get>d__0>(ET.Client.HttpClientHelper.<Get>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.HttpClientHelper.<Post>d__1>(ET.Client.HttpClientHelper.<Post>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.ResourcesLoaderComponentSystem.<LoadAllAssetsAsync>d__5<object>>(ET.Client.ResourcesLoaderComponentSystem.<LoadAllAssetsAsync>d__5<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.ResourcesLoaderComponentSystem.<LoadAssetAsync>d__3<object>>(ET.Client.ResourcesLoaderComponentSystem.<LoadAssetAsync>d__3<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.ResourcesLoaderComponentSystem.<LoadAssetAsync>d__4>(ET.Client.ResourcesLoaderComponentSystem.<LoadAssetAsync>d__4&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.RouterHelper.<CreateRouterSession>d__0>(ET.Client.RouterHelper.<CreateRouterSession>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.SessionHelper.<Call>d__1<object>>(ET.Client.SessionHelper.<Call>d__1<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.UIBagEventHandler.<OnCreate>d__0>(ET.Client.UIBagEventHandler.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.UIChatBigEventHandler.<OnCreate>d__0>(ET.Client.UIChatBigEventHandler.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.UIChatMiniEventHandler.<OnCreate>d__0>(ET.Client.UIChatMiniEventHandler.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.UIChooseRoleEventHandler.<OnCreate>d__0>(ET.Client.UIChooseRoleEventHandler.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.UIComponentSystem.<LoadUIObject>d__9>(ET.Client.UIComponentSystem.<LoadUIObject>d__9&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.UICreateRoleEventHandler.<OnCreate>d__0>(ET.Client.UICreateRoleEventHandler.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.UIJoystickEventHandler.<OnCreate>d__0>(ET.Client.UIJoystickEventHandler.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.UILoginEventHandler.<OnCreate>d__0>(ET.Client.UILoginEventHandler.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.UIMainEventHandler.<OnCreate>d__0>(ET.Client.UIMainEventHandler.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.UIServerListEventHandler.<OnCreate>d__0>(ET.Client.UIServerListEventHandler.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.ObjectWaitSystem.<Wait>d__4<object>>(ET.ObjectWaitSystem.<Wait>d__4<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.ObjectWaitSystem.<Wait>d__5<object>>(ET.ObjectWaitSystem.<Wait>d__5<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.RpcInfo.<Wait>d__7>(ET.RpcInfo.<Wait>d__7&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.SessionSystem.<Call>d__3>(ET.SessionSystem.<Call>d__3&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.SessionSystem.<Call>d__4>(ET.SessionSystem.<Call>d__4&)
		// System.Void ET.ETAsyncTaskMethodBuilder<uint>.Start<ET.Client.RouterHelper.<Connect>d__2>(ET.Client.RouterHelper.<Connect>d__2&)
		// object ET.Entity.AddChild<object,int>(int,bool)
		// object ET.Entity.AddChild<object,object,object>(object,object,bool)
		// object ET.Entity.AddChildWithId<object,int>(long,int,bool)
		// object ET.Entity.AddChildWithId<object,object>(long,object,bool)
		// object ET.Entity.AddChildWithId<object>(long,bool)
		// object ET.Entity.AddComponent<object,int,int>(int,int,bool)
		// object ET.Entity.AddComponent<object,int>(int,bool)
		// object ET.Entity.AddComponent<object,object,int>(object,int,bool)
		// object ET.Entity.AddComponent<object,object,object>(object,object,bool)
		// object ET.Entity.AddComponent<object>(bool)
		// object ET.Entity.AddComponentWithId<object,int,int>(long,int,int,bool)
		// object ET.Entity.AddComponentWithId<object,int>(long,int,bool)
		// object ET.Entity.AddComponentWithId<object,object,int>(long,object,int,bool)
		// object ET.Entity.AddComponentWithId<object,object,object>(long,object,object,bool)
		// object ET.Entity.AddComponentWithId<object>(long,bool)
		// object ET.Entity.GetChild<object>(long)
		// object ET.Entity.GetComponent<object>()
		// object ET.Entity.GetParent<object>()
		// System.Void ET.Entity.RemoveComponent<object>()
		// System.Void ET.EntitySystemSingleton.Awake<int,int>(ET.Entity,int,int)
		// System.Void ET.EntitySystemSingleton.Awake<int>(ET.Entity,int)
		// System.Void ET.EntitySystemSingleton.Awake<object,int>(ET.Entity,object,int)
		// System.Void ET.EntitySystemSingleton.Awake<object,object>(ET.Entity,object,object)
		// System.Void ET.EntitySystemSingleton.Awake<object>(ET.Entity,object)
		// long ET.EnumHelper.FromString<long>(string)
		// System.Void ET.EventSystem.Invoke<ET.NetComponentOnRead>(long,ET.NetComponentOnRead)
		// System.Void ET.EventSystem.Publish<object,ET.AppearanceChanged>(object,ET.AppearanceChanged)
		// System.Void ET.EventSystem.Publish<object,ET.BuffAdd>(object,ET.BuffAdd)
		// System.Void ET.EventSystem.Publish<object,ET.BuffRemove>(object,ET.BuffRemove)
		// System.Void ET.EventSystem.Publish<object,ET.BuffTick>(object,ET.BuffTick)
		// System.Void ET.EventSystem.Publish<object,ET.BuffUpdate>(object,ET.BuffUpdate)
		// System.Void ET.EventSystem.Publish<object,ET.CastBreak>(object,ET.CastBreak)
		// System.Void ET.EventSystem.Publish<object,ET.CastFinish>(object,ET.CastFinish)
		// System.Void ET.EventSystem.Publish<object,ET.CastHit>(object,ET.CastHit)
		// System.Void ET.EventSystem.Publish<object,ET.CastStart>(object,ET.CastStart)
		// System.Void ET.EventSystem.Publish<object,ET.ChangePosition>(object,ET.ChangePosition)
		// System.Void ET.EventSystem.Publish<object,ET.ChangeRotation>(object,ET.ChangeRotation)
		// System.Void ET.EventSystem.Publish<object,ET.Client.AfterCreateCurrentScene>(object,ET.Client.AfterCreateCurrentScene)
		// System.Void ET.EventSystem.Publish<object,ET.Client.AfterUnitCreate>(object,ET.Client.AfterUnitCreate)
		// System.Void ET.EventSystem.Publish<object,ET.Client.ChooseServer>(object,ET.Client.ChooseServer)
		// System.Void ET.EventSystem.Publish<object,ET.Client.EnterMapFinish>(object,ET.Client.EnterMapFinish)
		// System.Void ET.EventSystem.Publish<object,ET.Client.GetAllItems>(object,ET.Client.GetAllItems)
		// System.Void ET.EventSystem.Publish<object,ET.Client.HeightSync>(object,ET.Client.HeightSync)
		// System.Void ET.EventSystem.Publish<object,ET.Client.JoystickMove>(object,ET.Client.JoystickMove)
		// System.Void ET.EventSystem.Publish<object,ET.Client.KeyDown>(object,ET.Client.KeyDown)
		// System.Void ET.EventSystem.Publish<object,ET.Client.SceneChangeFinish>(object,ET.Client.SceneChangeFinish)
		// System.Void ET.EventSystem.Publish<object,ET.Client.SceneChangeStart>(object,ET.Client.SceneChangeStart)
		// System.Void ET.EventSystem.Publish<object,ET.Client.UIPing>(object,ET.Client.UIPing)
		// System.Void ET.EventSystem.Publish<object,ET.MoveStart>(object,ET.MoveStart)
		// System.Void ET.EventSystem.Publish<object,ET.MoveStop>(object,ET.MoveStop)
		// System.Void ET.EventSystem.Publish<object,ET.NumbericChange>(object,ET.NumbericChange)
		// ET.ETTask ET.EventSystem.PublishAsync<object,ET.Client.AppStartInitFinish>(object,ET.Client.AppStartInitFinish)
		// ET.ETTask ET.EventSystem.PublishAsync<object,ET.Client.LoginFinish>(object,ET.Client.LoginFinish)
		// ET.ETTask ET.EventSystem.PublishAsync<object,ET.Client.RemoteConfigLoaded>(object,ET.Client.RemoteConfigLoaded)
		// ET.ETTask ET.EventSystem.PublishAsync<object,ET.EntryEvent1>(object,ET.EntryEvent1)
		// ET.ETTask ET.EventSystem.PublishAsync<object,ET.EntryEvent2>(object,ET.EntryEvent2)
		// ET.ETTask ET.EventSystem.PublishAsync<object,ET.EntryEvent3>(object,ET.EntryEvent3)
		// object ET.MongoHelper.FromJson<object>(string)
		// object ET.ObjectPool.Fetch<object>()
		// System.Void ET.RandomGenerator.BreakRank<object>(System.Collections.Generic.List<object>)
		// object ET.World.AddSingleton<object>()
		// string Luban.StringUtil.CollectionToString<int,int>(System.Collections.Generic.IDictionary<int,int>)
		// string Luban.StringUtil.CollectionToString<int,long>(System.Collections.Generic.IDictionary<int,long>)
		// string Luban.StringUtil.CollectionToString<int,object>(System.Collections.Generic.IDictionary<int,object>)
		// string Luban.StringUtil.CollectionToString<int>(System.Collections.Generic.IEnumerable<int>)
		// string Luban.StringUtil.CollectionToString<object>(System.Collections.Generic.IEnumerable<object>)
		// System.Collections.Generic.List<object> MemoryPack.Formatters.ListFormatter.DeserializePackable<object>(MemoryPack.MemoryPackReader&)
		// System.Void MemoryPack.Formatters.ListFormatter.DeserializePackable<object>(MemoryPack.MemoryPackReader&,System.Collections.Generic.List<object>&)
		// System.Void MemoryPack.Formatters.ListFormatter.SerializePackable<object>(MemoryPack.MemoryPackWriter&,System.Collections.Generic.List<object>&)
		// MemoryPack.MemoryPackFormatter<object> MemoryPack.MemoryPackFormatterProvider.GetFormatter<object>()
		// bool MemoryPack.MemoryPackFormatterProvider.IsRegistered<object>()
		// System.Void MemoryPack.MemoryPackFormatterProvider.Register<object>(MemoryPack.MemoryPackFormatter<object>)
		// MemoryPack.IMemoryPackFormatter<object> MemoryPack.MemoryPackReader.GetFormatter<object>()
		// System.Void MemoryPack.MemoryPackReader.ReadPackable<object>(object&)
		// object MemoryPack.MemoryPackReader.ReadPackable<object>()
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<ET.ActorId>(ET.ActorId&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<Unity.Mathematics.float3>(Unity.Mathematics.float3&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<Unity.Mathematics.quaternion,int>(Unity.Mathematics.quaternion&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<Unity.Mathematics.quaternion>(Unity.Mathematics.quaternion&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,byte>(byte&,byte&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,ET.ActorId>(byte&,int&,ET.ActorId&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,Unity.Mathematics.float3>(byte&,int&,Unity.Mathematics.float3&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,int,int>(byte&,int&,int&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,int,long,Unity.Mathematics.float3>(byte&,int&,int&,long&,Unity.Mathematics.float3&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,int,long,long,long,int>(byte&,int&,int&,long&,long&,long&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,int,long>(byte&,int&,int&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,int>(byte&,int&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,long,Unity.Mathematics.float3,Unity.Mathematics.float3>(byte&,int&,long&,Unity.Mathematics.float3&,Unity.Mathematics.float3&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,long,Unity.Mathematics.float3,Unity.Mathematics.quaternion>(byte&,int&,long&,Unity.Mathematics.float3&,Unity.Mathematics.quaternion&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,long,int,long>(byte&,int&,long&,int&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,long,long,long,long,int>(byte&,int&,long&,long&,long&,long&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,long,long,long>(byte&,int&,long&,long&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,long,long>(byte&,int&,long&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,long>(byte&,int&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int>(byte&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,int,long,long>(byte&,long&,int&,long&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,long,int,int,Unity.Mathematics.float3,Unity.Mathematics.float3>(byte&,long&,long&,int&,int&,Unity.Mathematics.float3&,Unity.Mathematics.float3&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,long,long>(byte&,long&,long&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,long>(byte&,long&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long>(byte&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,uint>(byte&,uint&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte>(byte&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<int,int,int>(int&,int&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<int,int>(int&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<int>(int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<long,long>(long&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<long>(long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<uint>(uint&)
		// System.Void MemoryPack.MemoryPackReader.ReadValue<object>(object&)
		// object MemoryPack.MemoryPackReader.ReadValue<object>()
		// MemoryPack.IMemoryPackFormatter<object> MemoryPack.MemoryPackWriter.GetFormatter<object>()
		// System.Void MemoryPack.MemoryPackWriter.WritePackable<object>(object&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<ET.ActorId>(ET.ActorId&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<Unity.Mathematics.quaternion,int>(Unity.Mathematics.quaternion&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<byte,byte>(byte&,byte&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<int,int,int>(int&,int&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<int,int>(int&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<int>(int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<long,long>(long&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<long>(long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,byte>(byte,byte&,byte&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,ET.ActorId>(byte,byte&,int&,ET.ActorId&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,Unity.Mathematics.float3>(byte,byte&,int&,Unity.Mathematics.float3&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,int,int>(byte,byte&,int&,int&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,int,long,Unity.Mathematics.float3>(byte,byte&,int&,int&,long&,Unity.Mathematics.float3&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,int,long,long,long,int>(byte,byte&,int&,int&,long&,long&,long&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,int,long>(byte,byte&,int&,int&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,int>(byte,byte&,int&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,long,Unity.Mathematics.float3,Unity.Mathematics.float3>(byte,byte&,int&,long&,Unity.Mathematics.float3&,Unity.Mathematics.float3&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,long,Unity.Mathematics.float3,Unity.Mathematics.quaternion>(byte,byte&,int&,long&,Unity.Mathematics.float3&,Unity.Mathematics.quaternion&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,long,int,long>(byte,byte&,int&,long&,int&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,long,long,long,long,int>(byte,byte&,int&,long&,long&,long&,long&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,long,long,long>(byte,byte&,int&,long&,long&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,long,long>(byte,byte&,int&,long&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,long>(byte,byte&,int&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int>(byte,byte&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,int,long,long>(byte,byte&,long&,int&,long&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,long,int,int,Unity.Mathematics.float3,Unity.Mathematics.float3>(byte,byte&,long&,long&,int&,int&,Unity.Mathematics.float3&,Unity.Mathematics.float3&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,long,long>(byte,byte&,long&,long&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,long>(byte,byte&,long&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long>(byte,byte&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,uint>(byte,byte&,uint&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte>(byte,byte&)
		// System.Void MemoryPack.MemoryPackWriter.WriteValue<object>(object&)
		// object MongoDB.Bson.Serialization.BsonSerializer.Deserialize<object>(MongoDB.Bson.IO.IBsonReader,System.Action<MongoDB.Bson.Serialization.BsonDeserializationContext.Builder>)
		// object MongoDB.Bson.Serialization.BsonSerializer.Deserialize<object>(string,System.Action<MongoDB.Bson.Serialization.BsonDeserializationContext.Builder>)
		// MongoDB.Bson.Serialization.IBsonSerializer<object> MongoDB.Bson.Serialization.BsonSerializer.LookupSerializer<object>()
		// object MongoDB.Bson.Serialization.IBsonSerializerExtensions.Deserialize<object>(MongoDB.Bson.Serialization.IBsonSerializer<object>,MongoDB.Bson.Serialization.BsonDeserializationContext)
		// object ReferenceCollector.Get<object>(string)
		// object System.Activator.CreateInstance<object>()
		// object[] System.Array.Empty<object>()
		// int System.Linq.Enumerable.FirstOrDefault<int>(System.Collections.Generic.IEnumerable<int>)
		// ET.RpcInfo[] System.Linq.Enumerable.ToArray<ET.RpcInfo>(System.Collections.Generic.IEnumerable<ET.RpcInfo>)
		// object[] System.Linq.Enumerable.ToArray<object>(System.Collections.Generic.IEnumerable<object>)
		// System.Collections.Generic.List<object> System.Linq.Enumerable.ToList<object>(System.Collections.Generic.IEnumerable<object>)
		// System.Collections.Generic.IEnumerable<int> System.Linq.Enumerable.Where<int>(System.Collections.Generic.IEnumerable<int>,System.Func<int,bool>)
		// byte& System.Runtime.CompilerServices.Unsafe.Add<byte>(byte&,int)
		// object& System.Runtime.CompilerServices.Unsafe.AsRef<object>(object&)
		// ET.ActorId System.Runtime.CompilerServices.Unsafe.ReadUnaligned<ET.ActorId>(byte&)
		// Unity.Mathematics.float3 System.Runtime.CompilerServices.Unsafe.ReadUnaligned<Unity.Mathematics.float3>(byte&)
		// Unity.Mathematics.quaternion System.Runtime.CompilerServices.Unsafe.ReadUnaligned<Unity.Mathematics.quaternion>(byte&)
		// byte System.Runtime.CompilerServices.Unsafe.ReadUnaligned<byte>(byte&)
		// int System.Runtime.CompilerServices.Unsafe.ReadUnaligned<int>(byte&)
		// long System.Runtime.CompilerServices.Unsafe.ReadUnaligned<long>(byte&)
		// uint System.Runtime.CompilerServices.Unsafe.ReadUnaligned<uint>(byte&)
		// int System.Runtime.CompilerServices.Unsafe.SizeOf<ET.ActorId>()
		// int System.Runtime.CompilerServices.Unsafe.SizeOf<Unity.Mathematics.float3>()
		// int System.Runtime.CompilerServices.Unsafe.SizeOf<Unity.Mathematics.quaternion>()
		// int System.Runtime.CompilerServices.Unsafe.SizeOf<byte>()
		// int System.Runtime.CompilerServices.Unsafe.SizeOf<int>()
		// int System.Runtime.CompilerServices.Unsafe.SizeOf<long>()
		// int System.Runtime.CompilerServices.Unsafe.SizeOf<uint>()
		// System.Void System.Runtime.CompilerServices.Unsafe.WriteUnaligned<ET.ActorId>(byte&,ET.ActorId)
		// System.Void System.Runtime.CompilerServices.Unsafe.WriteUnaligned<Unity.Mathematics.float3>(byte&,Unity.Mathematics.float3)
		// System.Void System.Runtime.CompilerServices.Unsafe.WriteUnaligned<Unity.Mathematics.quaternion>(byte&,Unity.Mathematics.quaternion)
		// System.Void System.Runtime.CompilerServices.Unsafe.WriteUnaligned<byte>(byte&,byte)
		// System.Void System.Runtime.CompilerServices.Unsafe.WriteUnaligned<int>(byte&,int)
		// System.Void System.Runtime.CompilerServices.Unsafe.WriteUnaligned<long>(byte&,long)
		// System.Void System.Runtime.CompilerServices.Unsafe.WriteUnaligned<uint>(byte&,uint)
		// System.Threading.Tasks.Task<object> System.Threading.Tasks.TaskFactory.StartNew<object>(System.Func<object>,System.Threading.CancellationToken)
		// object[] UnityEngine.Component.GetComponents<object>()
		// object UnityEngine.GameObject.AddComponent<object>()
		// object UnityEngine.GameObject.GetComponent<object>()
		// object[] UnityEngine.GameObject.GetComponents<object>()
		// object UnityEngine.Object.Instantiate<object>(object,UnityEngine.Transform,bool)
		// YooAsset.AllAssetsHandle YooAsset.ResourcePackage.LoadAllAssetsAsync<object>(string,uint)
		// YooAsset.AssetHandle YooAsset.ResourcePackage.LoadAssetAsync<object>(string,uint)
		// string string.Join<int>(string,System.Collections.Generic.IEnumerable<int>)
		// string string.Join<object>(string,System.Collections.Generic.IEnumerable<object>)
		// string string.JoinCore<int>(System.Char*,int,System.Collections.Generic.IEnumerable<int>)
		// string string.JoinCore<object>(System.Char*,int,System.Collections.Generic.IEnumerable<object>)
	}
}