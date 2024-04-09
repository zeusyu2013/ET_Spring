/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class UIJoystickComponent: Entity, IAwake, IDestroy
    {
        public GComponent GCanvas { get; set; }
        public GButton GCanvas_Joystick { get; set; }
        public GImage GCanvas_Joystick_Tumb { get; set; }
        public GGraph GCanvas_TouchArea { get; set; }
    }
}