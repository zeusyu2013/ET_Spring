using System;
using Unity.Mathematics;

namespace ET.Server
{
    public static class BattleMessageHelper
    {
        public static void SendClient(Unit unit, IMessage message, MessageNotifyType notifyType)
        {
            if (unit == null || unit.IsDisposed)
            {
                return;
            }

            if (unit.GetComponent<AOIEntity>() == null)
            {
                return;
            }

            switch (notifyType)
            {
                case MessageNotifyType.MessageNotifyType_Self:
                    MapMessageHelper.SendToClient(unit, message);
                    break;
                case MessageNotifyType.MessageNotifyType_Broadcast:
                    MapMessageHelper.Broadcast(unit, message);
                    break;
                case MessageNotifyType.MessageNotifyType_BroadcastExceptMe:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(notifyType), notifyType, null);
            }
        }

        public static void ForceSetPosition(this Unit unit, float3 position, bool sendMsg = false)
        {
            if (!sendMsg)
            {
                return;
            }
            
            M2C_SetPosition m2CSetPosition = M2C_SetPosition.Create();
            m2CSetPosition.UnitId = unit.Id;
            m2CSetPosition.Position = unit.Position;
            m2CSetPosition.Rotation = unit.Rotation;
            
            SendClient(unit, m2CSetPosition, MessageNotifyType.MessageNotifyType_Broadcast);
        }
    }
}