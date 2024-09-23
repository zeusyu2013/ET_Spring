/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class UILoginPanelComponent: Entity, IAwake, IDestroy
    {
        public GComponent Ginput_account { get; set; }
        public GComponent Gaccount_password { get; set; }
        public GButton Glogin_btn { get; set; }
        public GButton Gnotice_btn { get; set; }
        public GButton Guser_btn { get; set; }
    }
}