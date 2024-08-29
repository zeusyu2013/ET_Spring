/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;

namespace ET.Client
{
    [EntitySystemOf(typeof(UIBagPanelComponent))]
    [FriendOf(typeof(UIBagPanelComponent))]
    public static partial class UIBagPanelComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIBagPanelComponent self)
        {
            UI ui = self.Parent as UI;
            self.Gmodel_viewer = ui.Component.GetChildAt(1) as GLoader;
            self.Gbag_list = ui.Component.GetChildAt(3) as GList;
            self.Gequip_list = ui.Component.GetChildAt(4) as GComponent;
            self.Gequip_list_weapon = self.Gequip_list.GetChildAt(0) as GComponent;
            self.Gequip_list_neck = self.Gequip_list.GetChildAt(1) as GComponent;
            self.Gequip_list_shoulder = self.Gequip_list.GetChildAt(2) as GComponent;
            self.Gequip_list_chest = self.Gequip_list.GetChildAt(3) as GComponent;
            self.Gequip_list_hand = self.Gequip_list.GetChildAt(4) as GComponent;
            self.Gequip_list_leg = self.Gequip_list.GetChildAt(5) as GComponent;
            self.Gequip_list_shoe = self.Gequip_list.GetChildAt(6) as GComponent;
            self.Gequip_list_ring = self.Gequip_list.GetChildAt(7) as GComponent;
        }
        [EntitySystem]
        private static void Destroy(this UIBagPanelComponent self)
        {
            self.Gmodel_viewer = null;
            self.Gbag_list = null;
            self.Gequip_list = null;
            self.Gequip_list_weapon = null;
            self.Gequip_list_neck = null;
            self.Gequip_list_shoulder = null;
            self.Gequip_list_chest = null;
            self.Gequip_list_hand = null;
            self.Gequip_list_leg = null;
            self.Gequip_list_shoe = null;
            self.Gequip_list_ring = null;
        }
    }
}