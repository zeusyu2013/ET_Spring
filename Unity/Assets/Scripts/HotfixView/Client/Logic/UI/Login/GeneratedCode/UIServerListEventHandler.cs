/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
namespace ET.Client
{
    [UIEvent(UIName.UIServerList)]
    public class UIServerListEventHandler : AUIEvent
    {
        public override async ETTask<UI> OnCreate(UIComponent uiComponent)
        {
            GObject gOject = await uiComponent.LoadUIObject(UIPackageName.Login, UIName.UIServerList);
            if (gOject == null) return null;
            UI ui = uiComponent.AddChild<UI, string, string>(UIPackageName.Login, UIName.UIServerList);
            ui.Component = gOject as GComponent;
            ui.AddComponent<UIServerListComponent>();
            ui.AddComponent<UIServerListLogicComponent>();
            return ui;
        }

        public override void OnShow(UIComponent uiComponent, UI ui)
        {
            var logicComponent = ui.GetComponent<UIServerListLogicComponent>();
            logicComponent.OnShow();
        }

        public override void OnHide(UIComponent uiComponent, UI ui)
        {
            var logicComponent = ui.GetComponent<UIServerListLogicComponent>();
            logicComponent.OnHide();
        }
    }
}