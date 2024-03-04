namespace ET.Client
{
	[Event(SceneType.Current)]
	public class LoginFinish_RemoveLoginUI: AEvent<Scene, LoginFinish>
	{
		protected override async ETTask Run(Scene scene, LoginFinish args)
		{
			//FGUIHelper.Remove(scene, UIType.UILogin);
			await ETTask.CompletedTask;
		}
	}
}
