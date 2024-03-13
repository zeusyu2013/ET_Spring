﻿namespace ET.Client
{
	[Event(SceneType.Demo)]
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
			ui.GetComponent<UILoginLogicComponent>().EnterMap().Coroutine();
			UIHelper.Remove(scene, UIName.UILogin);
			//var loginComponent = ui.GetComponent<UILoginComponent>();
			//loginComponent.GCanvas_LoginCtrl.selectedIndex = 1;
	
			await ETTask.CompletedTask;
		}
	}
}