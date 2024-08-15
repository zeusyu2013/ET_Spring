
using FairyGUI;
using Unity.Mathematics;
using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(UIJoystickLogicComponent))]
    [FriendOf(typeof(UIJoystickLogicComponent))]
    public static partial class UIJoystickLogicComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIJoystickLogicComponent self)
        {
            var view = self.GetParent<UI>().GetComponent<UIJoystickComponent>();
            
            view.GCanvas_TouchArea.onTouchBegin.Add(self.OnTouchBegin);
            view.GCanvas_TouchArea.onTouchMove.Add(self.OnTouchMove);
            view.GCanvas_TouchArea.onTouchEnd.Add(self.OnTouchEnd);
            self.Thumb = view.GCanvas_Joystick.GetChild("Tumb") as GImage;

            self.FixX = view.GCanvas_Joystick.x;
            self.FixY = view.GCanvas_Joystick.y;
            self.TouchId = -1;
            self.Radius = 100;
        }
        [EntitySystem]
        private static void Destroy(this UIJoystickLogicComponent self)
        {
            
        }
        public static void OnHide(this UIJoystickLogicComponent self)
        {
            
        }

        public static void OnShow(this UIJoystickLogicComponent self)
        {
            
        }

        public static void OnTouchBegin(this UIJoystickLogicComponent self, EventContext context)
        {
            var inputEvent = context.inputEvent;
          
            if (self.TouchId != -1)
            {
                return;
            }

            //var inputEvent = context.inputEvent;
            self.TouchId = inputEvent.touchId;
            // 获取点击的世界坐标
            Vector2 position = GRoot.inst.GlobalToLocal(new Vector2(inputEvent.x, inputEvent.y));
            var view = self.GetParent<UI>().GetComponent<UIJoystickComponent>();
            view.GCanvas_Joystick.selected = true;
            context.CaptureTouch();
            self.SetObjectPostion(position);
        }

        public static void OnTouchMove(this UIJoystickLogicComponent self, EventContext context)
        {
            var inputEvent = context.inputEvent;
            if (inputEvent.touchId != self.TouchId || self.TouchId == -1)
            {
                return;
            }
            Vector2 position = GRoot.inst.GlobalToLocal(new Vector2(inputEvent.x, inputEvent.y));
            self.SetObjectPostion(position);
        }

        public static void OnTouchEnd(this UIJoystickLogicComponent self, EventContext context)
        {
            var inputEvent = context.inputEvent;
            if (self.TouchId == -1 || inputEvent.touchId != self.TouchId)
            {
                return;
            }
            self.TouchId = -1;
            var view = self.GetParent<UI>().GetComponent<UIJoystickComponent>();

            view.GCanvas_Joystick.selected = false;
            
            EventSystem.Instance.Publish(self.Root(), new JoystickMove(){ DeltaX = 0, DeltaY = 0});
            self.Scene().CurrentScene().GetComponent<OperaComponent>().Stop();
        }

        public static float SetObjectPostion(this UIJoystickLogicComponent self, Vector2 position)
        {
          
            var view = self.GetParent<UI>().GetComponent<UIJoystickComponent>();
            float centerX = view.GCanvas_Joystick.x + view.GCanvas_Joystick.width * 0.5f;
            float centerY = view.GCanvas_Joystick.y + view.GCanvas_Joystick.height * 0.5f;

            float deltaX = position.x - centerX;
            float deltaY = position.y - centerY;
            
            float rad = Mathf.Atan2(deltaY, deltaX);
            float degree = rad * Mathf.Rad2Deg + 90;
            self.Thumb.rotation = degree;

            float maxX = self.Radius * Mathf.Cos(rad);
            float maxY = self.Radius * Mathf.Sin(rad);
            float absDeltaX = Mathf.Abs(deltaX);
            float absDeltaY = Mathf.Abs(deltaY);
            float absMaxX = Mathf.Abs(maxX);
            float absMaxY = Mathf.Abs(maxY);
            if (absDeltaX > absMaxX)
            {
                deltaX = maxX;
            }

            if (absDeltaY > absMaxY)
            {
                deltaY = maxY;
            }

            float thumbCenterX = view.GCanvas_Joystick.width * 0.5f;
            float thumbCenterY = view.GCanvas_Joystick.height * 0.5f;
            
            self.Thumb.SetXY(thumbCenterX + deltaX - self.Thumb.width * 0.5f, thumbCenterY + deltaY - self.Thumb.height * 0.5f);

            //float3 direction = new float3(deltaX, 0, deltaY);
            //self.Scene().CurrentScene().GetComponent<OperaComponent>().JoyMove(math.normalize(direction));
            EventSystem.Instance.Publish(self.Root(), new JoystickMove(){ DeltaX = deltaX, DeltaY = deltaY});
            return degree;
        }
        
    }
}