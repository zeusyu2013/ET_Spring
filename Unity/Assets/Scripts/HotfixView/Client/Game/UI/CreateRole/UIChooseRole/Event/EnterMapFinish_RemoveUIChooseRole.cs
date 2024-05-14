namespace ET.Client.Event
{
    [Event(SceneType.MainClient)]
    public class EnterMapFinish_RemoveUIChooseRole : AEvent<Scene, EnterMapFinish>
    {
        protected override async ETTask Run(Scene scene, EnterMapFinish args)
        {
            UIComponent uiComponent = scene.GetComponent<UIComponent>();
            var ui = uiComponent.GetPanel(UIName.UIChooseRole);
            if (ui == null)
            {
                return;
            }
            
            UIHelper.Remove(scene, UIName.UIChooseRole).Coroutine();
            await ETTask.CompletedTask;
        }
    } 
}
