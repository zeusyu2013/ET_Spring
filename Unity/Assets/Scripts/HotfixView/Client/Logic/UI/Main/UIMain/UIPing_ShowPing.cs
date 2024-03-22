namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class UIPing_ShowPing : AEvent<Scene, UIPing>
    {
        protected override async ETTask Run(Scene scene, UIPing a)
        {
            var logicComponent = UIHelper.GetUIComponent<UIMainLogicComponent>(scene, UIName.UIMain);

            if (logicComponent == null)
            {
                return;
            }

            logicComponent.ShowPing(a.Ping);            
            await ETTask.CompletedTask;
        }
    }
}

