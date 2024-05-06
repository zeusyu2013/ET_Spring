﻿namespace ET.Client
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
		
			await EnterMapHelper.EnterMapAsync(scene);
			UIHelper.Remove(scene, UIName.UILogin).Coroutine();
	
			await ETTask.CompletedTask;
		}
		
	
	}
}
