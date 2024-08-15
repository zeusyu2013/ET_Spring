using FairyGUI;

namespace ET.Client
{
    public static partial class Util
    {
        public static void SetItemIcon(GButton btn, GameItemInfo itemInfo)
        {
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(itemInfo.Config);

            SetItemIcon(btn, itemConfig);
        }

        public static void SetItemIcon(GButton btn, ItemConfig itemConfig)
        {
            if (itemConfig == null)
            {
                return;
            }
            GComponent iconCom = btn.GetChild("IconCom") as GComponent;
            GLoader iconLoader = iconCom.GetChild("BgLoader") as GLoader;
            GLoader bgIcon = iconCom.GetChild("IconLoader") as GLoader;
            
            
        }
        
    }
}

