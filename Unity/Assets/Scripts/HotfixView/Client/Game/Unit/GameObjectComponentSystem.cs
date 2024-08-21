using System;
using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(GameObjectComponent))]
    public static partial class GameObjectComponentSystem
    {
        [EntitySystem]
        private static void Destroy(this GameObjectComponent self)
        {
            UnityEngine.Object.Destroy(self.GameObject);
            self.GameObject = null;
        }

        [EntitySystem]
        private static void Awake(this GameObjectComponent self)
        {
        }

        public static Transform GetBindPoint(this GameObjectComponent self, ModelBindPoint point)
        {
            Transform bindPoint = null;
            switch (point)
            {
                case ModelBindPoint.ModelHead:
                    bindPoint = self.Head;
                    break;
                case ModelBindPoint.ModelNeck:
                    bindPoint = self.Neck;
                    break;
                case ModelBindPoint.ModelShoulder:
                    bindPoint = self.Shoulder;
                    break;
                case ModelBindPoint.ModelChest:
                    bindPoint = self.Chest;
                    break;
                case ModelBindPoint.ModelLeftLeg:
                    bindPoint = self.LeftLeg;
                    break;
                case ModelBindPoint.ModelRightLeg:
                    bindPoint = self.RightLeg;
                    break;
                case ModelBindPoint.ModelLeftFoot:
                    bindPoint = self.LeftFoot;
                    break;
                case ModelBindPoint.ModelRightFoot:
                    bindPoint = self.RightFoot;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(point), point, null);
            }

            return bindPoint;
        }
    }
}