namespace ET.Client
{
    /// <summary>
    /// 用于收集AUIEvent
    /// </summary>
    public class UIEventAttribute : BaseAttribute
    {
        public string PanelName { get; }

        public UIEventAttribute(string panelName)
        {
            this.PanelName = panelName;
        }
    }
}
