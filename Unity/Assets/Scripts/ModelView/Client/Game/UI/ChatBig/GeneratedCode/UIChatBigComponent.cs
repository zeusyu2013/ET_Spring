/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class UIChatBigComponent: Entity, IAwake, IDestroy
    {
        public GComponent GCanvas { get; set; }
        public GList GCanvas_List { get; set; }
        public GTextInput GCanvas_InputText { get; set; }
        public GButton GCanvas_SendBtn { get; set; }
    }
}