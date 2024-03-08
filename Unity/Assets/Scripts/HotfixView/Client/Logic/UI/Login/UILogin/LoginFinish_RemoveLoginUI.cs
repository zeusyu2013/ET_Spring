namespace ET.Client
{
	[Event(SceneType.Demo)]
	public class LoginFinish_RemoveLoginUI: AEvent<Scene, EnterMapFinish>
	{
		protected override async ETTask Run(Scene scene, EnterMapFinish args)
		{
			UIComponent uiComponent = scene.GetComponent<UIComponent>();
			var ui = uiComponent.GetPanel(UIName.UILogin);
			if (ui == null)
			{
				return;
			}
			
			ui.GetComponent<UILoginLogicComponent>().EnterMap().Coroutine();
			UIHelper.Remove(scene, UIName.UILogin);
			await ETTask.CompletedTask;
		}
	}
}
