namespace ET.Client
{
    [Event(SceneType.MainClient)]
    public class ChooseServer_RefreshUI : AEvent<Scene, ChooseServer>
    {
        protected override async ETTask Run(Scene scene, ChooseServer a)
        {
            UIComponent uiComponent = scene.GetComponent<UIComponent>();
            var ui = uiComponent.GetPanel(UIName.UILogin);
            if (ui == null)
            {
                return;
            }
            
            Servers serverInfo = scene.GetComponent<PlayerPrefsComponent>().ServerInfo;
            var view = ui.GetComponent<UILoginComponent>();
            view.GCanvas_ServerName.text = serverInfo.server_name;

            await ETTask.CompletedTask;
        }
    }
}

