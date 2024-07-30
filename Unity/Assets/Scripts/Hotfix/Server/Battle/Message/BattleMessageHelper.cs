using System;

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
    }
}