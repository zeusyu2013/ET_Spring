
namespace ET
{
    public partial class UIConfigCategory
    {
        public UIConfig GetConfigByName(string panelName)
        {
            foreach (var data in _dataList)
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