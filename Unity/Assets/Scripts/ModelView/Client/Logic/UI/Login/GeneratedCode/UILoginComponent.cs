/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class UILoginComponent: Entity, IAwake, IDestroy
    {
        public Controller GLoginCtrl { get; set; }
        public GButton GLoginBtn { get; set; }
        public GTextInput GAccountText { get; set; }
        public GTextInput GPasswordText { get; set; }
        public GButton GEnterBtn { get; set; }
    }
}