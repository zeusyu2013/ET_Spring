/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class UICreateRoleComponent: Entity, IAwake, IDestroy
    {
        public GComponent GCanvas { get; set; }
        public GTextInput GCanvas_NameText { get; set; }
        public GButton GCanvas_ConfimBtn { get; set; }
        public GList GCanvas_List { get; set; }
        public GLoader GCanvas_ModelLoader { get; set; }
        public GTextField GCanvas_RaceText { get; set; }
        public GTextField GCanvas_CharacterText { get; set; }
    }
}