/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class UILoginComponent: Entity, IAwake, IDestroy
    {
        public GComponent GCanvas { get; set; }
        public Controller GCanvas_LoginCtrl { get; set; }
        public GButton GCanvas_LoginBtn { get; set; }
        public GTextInput GCanvas_AccountText { get; set; }
        public GTextInput GCanvas_PasswordText { get; set; }
        public GButton GCanvas_SelectServerBtn { get; set; }
        public GGraph GCanvas_ServerNameBg { get; set; }
        public GTextField GCanvas_ServerName { get; set; }
    }
}