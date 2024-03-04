namespace ET.Client
{
    /// <summary>
    /// 用创建界面的脚本
    /// 每一个UI都会有个一继承这个组件的类，方便UIComponent调用
    /// </summary>
    [EnableClass]
    public abstract class AUIEvent
    {
        // 界面创建
        public abstract ETTask<UI> OnCreate(UIComponent uiComponent);
        // 界面显示
        public abstract void OnShow(UIComponent uiComponent, UI ui);
        // 界面隐藏
        public abstract void OnHide(UIComponent uiComponent, UI ui);
    }
}