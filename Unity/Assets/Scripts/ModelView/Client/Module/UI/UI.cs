using FairyGUI;

namespace ET.Client
{
    [ChildOf]
    public sealed class UI: Entity, IAwake<string, string>, IDestroy
    {
        // 界面组件
        public GComponent Component { get; set; }
        // 界面名字
        public string PanelName { get; set; }
        // 包名
        public string PackageName { get; set; }
        // 层
        public int Layer { get; set; }
        // 配置数据
        public UIConfig UIConfig { get; set; }
        // 显示状态
        public bool IsShowing { get; set; }

    }   
}