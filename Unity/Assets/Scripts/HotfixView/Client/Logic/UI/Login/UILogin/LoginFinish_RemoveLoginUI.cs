namespace ET.Client
{
	[Event(SceneType.Demo)]
	public class LoginFinish_RemoveLoginUI: AEvent<Scene, EnterMapFinish>
	{
		protected override async ETTask Run(Scene scene, EnterMapFinish args)
		{
			UIHelper.Remove(scene, UIName.UILogin);
			await ETTask.CompletedTask;
		}
	}
}
