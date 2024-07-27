using Unity.Mathematics;

namespace ET.Server
{
    [FriendOfAttribute(typeof(ET.Server.ReliveComponent))]
    public static class ReliveHelper
    {
        public static bool IsAlive(this Unit unit)
        {
            return unit.GetComponent<ReliveComponent>()?.Alive ?? true;
        }

        public static int SetRelive(this Unit unit)
        {
            if (unit.IsAlive())
            {
                return ErrorCode.ERR_AlreadyAlive;
            }
            
            unit.DoRelive(unit.Position, 1);

            return ErrorCode.ERR_Success;
        }
        
        public static int SetRelive(this Unit unit, float3 pos)
        {
            if (unit.IsAlive())
            {
                return ErrorCode.ERR_AlreadyAlive;
            }
            
            unit.DoRelive(pos, 1);

            return ErrorCode.ERR_Success;
        }

        private static void DoRelive(this Unit unit, float3 pos, float hpRatio)
        {
            if (unit.IsAlive())
            {
                return;
            }

            unit.Position = pos;

            NumericComponent numericComponent = unit.GetComponent<NumericComponent>();
            if (numericComponent != null)
            {
                numericComponent[GamePropertyType.GamePropertyType_Hp] = math.clamp(
                    (int)(numericComponent[GamePropertyType.GamePropertyType_MaxHp] * hpRatio), 1,
                    numericComponent[GamePropertyType.GamePropertyType_MaxHp]);
            }

            unit.GetComponent<ReliveComponent>().Alive = true;
        }
    }
}