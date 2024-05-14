namespace ET.Client
{
	[Event(SceneType.MainClient)]
	public class LoginFinish_CreateLobbyUI: AEvent<Scene, LoginFinish>
	{
		protected override async ETTask Run(Scene scene, LoginFinish args)
		{
			UIComponent uiComponent = scene.GetComponent<UIComponent>();
			var ui = uiComponent.GetPanel(UIName.UILogin);
			if (ui == null)
			{
				return;
			}

			int error = await LoginHelper.GetRoleInfos(scene);
			if (error != ErrorCode.ERR_Success)
			{
				return;
			}
			GameRoleInfoComponent gameRoleInfoComponent = scene.GetComponent<GameRoleInfoComponent>();
			var roleInfos = gameRoleInfoComponent.GetGameRoleInfos();
			UIHelper.Remove(scene, UIName.UILogin).Coroutine();
			// 如果没有角色就打开创建角色界面
			if (roleInfos.Count <= 0)
			{
				UIHelper.Create(scene, UIName.UICreateRole).Coroutine();
				return;
			}

			if (args.UnitId <= 0)
			{
				UIHelper.Create(scene, UIName.UIChooseRole).Coroutine();
				return;
			}
			
			// 进入场景
			await EnterMapHelper.EnterMapAsync(scene, args.UnitId);
		}
		
	
	}
}
