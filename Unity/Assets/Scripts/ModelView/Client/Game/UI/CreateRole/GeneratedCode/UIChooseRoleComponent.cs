/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class UIChooseRoleComponent: Entity, IAwake, IDestroy
    {
        public GComponent GCanvas { get; set; }
        public GList GCanvas_List { get; set; }
        public GButton GCanvas_EnterBtn { get; set; }
        public GButton GCanvas_DeleteBtn { get; set; }
        public GTextField GCanvas_RaceText { get; set; }
        public GTextField GCanvas_CharacterText { get; set; }
        public GLoader GCanvas_IconLoader { get; set; }
    }
}