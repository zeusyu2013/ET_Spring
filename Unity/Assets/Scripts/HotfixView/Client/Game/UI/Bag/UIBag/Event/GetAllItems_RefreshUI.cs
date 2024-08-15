namespace ET.Client
{
    [Event(SceneType.MainClient)]
    public class GetAllItems_RefreshUI : AEvent<Scene, GetAllItems>
    {
        protected override async ETTask Run(Scene scene, GetAllItems args)
        {
            var logicComponent = UIHelper.GetUIComponent<UIBagLogicComponent>(scene, UIName.UIBag);
            if (logicComponent == null)
            {
                return;
            }
            
            await ETTask.CompletedTask;
        }
    }
}


