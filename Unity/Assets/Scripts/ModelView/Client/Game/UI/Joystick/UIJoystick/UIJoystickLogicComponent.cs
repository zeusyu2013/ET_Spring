/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class UIJoystickLogicComponent: Entity, IAwake, IDestroy
    {
        // 触碰Id
        public int TouchId;
        // 固定位置X， Y
        public float FixX;
        public float FixY;

        // 遥感中间的圆
        public GImage Thumb;
        // 半径
        public float Radius;
    }
}