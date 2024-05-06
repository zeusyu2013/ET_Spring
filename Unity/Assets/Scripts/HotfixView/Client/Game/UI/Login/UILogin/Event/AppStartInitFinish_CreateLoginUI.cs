﻿namespace ET.Client
{
	[Event(SceneType.MainClient)]
	public class AppStartInitFinish_CreateLoginUI: AEvent<Scene, AppStartInitFinish>
	{
		protected override async ETTask Run(Scene root, AppStartInitFinish args)
		{
			await root.GetComponent<RemoteConfigComponent>().GetRemoteConfig();
			
			await UIHelper.Create(root, UIName.UILogin);
		}
	}
}
