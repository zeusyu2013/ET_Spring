using Unity.Mathematics;

namespace ET
{
    public static partial class UnitHelper
    {
        public static void SetRotation(this Unit unit, quaternion rotation)
        {
            NumericComponent numericComponent = unit.GetComponent<NumericComponent>();
            if (numericComponent == null)
            {
                return;
            }

            int cantRotate = numericComponent.GetAsInt(GamePropertyType.GamePropertyType_CantRotate);
            if (cantRotate > 0)
            {
                return;
            }

            unit.Rotation = rotation;
        }
    }
}