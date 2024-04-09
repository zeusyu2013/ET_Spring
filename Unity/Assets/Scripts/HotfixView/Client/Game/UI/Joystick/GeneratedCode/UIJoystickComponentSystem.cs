/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;

namespace ET.Client
{
    [EntitySystemOf(typeof(UIJoystickComponent))]
    [FriendOf(typeof(UIJoystickComponent))]
    public static partial class UIJoystickComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIJoystickComponent self)
        {
            UI ui = self.Parent as UI;
            self.GCanvas = ui.Component.GetChildAt(0) as GComponent;
            self.GCanvas_Joystick = self.GCanvas.GetChildAt(0) as GButton;
            self.GCanvas_Joystick_Tumb = self.GCanvas_Joystick.GetChildAt(1) as GImage;
            self.GCanvas_TouchArea = self.GCanvas.GetChildAt(1) as GGraph;
        }
        [EntitySystem]
        private static void Destroy(this UIJoystickComponent self)
        {
            self.GCanvas = null;
            self.GCanvas_Joystick = null;
            self.GCanvas_Joystick_Tumb = null;
            self.GCanvas_TouchArea = null;
        }
    }
}