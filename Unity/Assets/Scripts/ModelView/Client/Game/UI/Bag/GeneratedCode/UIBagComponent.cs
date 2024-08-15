/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class UIBagComponent: Entity, IAwake, IDestroy
    {
        public GComponent GCanvas { get; set; }
        public Controller GCanvas_TabCtrl { get; set; }
        public GComponent GCanvas_List { get; set; }
        public GList GCanvas_List_List { get; set; }
        public GButton GCanvas_CloseBtn { get; set; }
        public GButton GCanvas_Tab1 { get; set; }
        public GButton GCanvas_Tab2 { get; set; }
        public GButton GCanvas_Tab3 { get; set; }
        public GButton GCanvas_Tab4 { get; set; }
    }
}