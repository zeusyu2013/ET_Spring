/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class UIBagPanelComponent: Entity, IAwake, IDestroy
    {
        public GLoader Gmodel_viewer { get; set; }
        public GList Gbag_list { get; set; }
        public GComponent Gequip_list { get; set; }
        public GComponent Gequip_list_weapon { get; set; }
        public GComponent Gequip_list_neck { get; set; }
        public GComponent Gequip_list_shoulder { get; set; }
        public GComponent Gequip_list_chest { get; set; }
        public GComponent Gequip_list_hand { get; set; }
        public GComponent Gequip_list_leg { get; set; }
        public GComponent Gequip_list_shoe { get; set; }
        public GComponent Gequip_list_ring { get; set; }
    }
}