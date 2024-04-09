/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class UIServerListComponent: Entity, IAwake, IDestroy
    {
        public GComponent GCanvas { get; set; }
        public GList GCanvas_ServerList { get; set; }
        public GButton GCanvas_CloseBtn { get; set; }
        public GList GCanvas_DisList { get; set; }
    }
}