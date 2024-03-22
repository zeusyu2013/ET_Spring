
namespace ET
{
    public partial class UIConfigCategory
    {
        public UIConfig GetConfigByName(string panelName)
        {
            foreach (var data in this.DataList)
            {
                if (data.Name == panelName)
                {
                    return data;
                }
            }
        
            return null;
        }
    }
}