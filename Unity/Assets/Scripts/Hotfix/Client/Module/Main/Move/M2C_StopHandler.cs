﻿namespace ET.Client
{
    [MessageHandler(SceneType.MainClient)]
    public class M2C_StopHandler: MessageHandler<Scene, M2C_Stop>
    {
        protected override async ETTask Run(Scene root, M2C_Stop message)
        {
            Unit unit = root.CurrentScene().GetComponent<UnitComponent>().Get(message.Id);
            if (unit == null)
            {
                return;
            }

            if (unit.IsMyUnit() && message.Error == ErrorCode.ERR_Success)
            {
                unit.GetComponent<ObjectWait>()?.Notify(new Wait_UnitStop() { Error = 0 });
                return;
            }

            MoveComponent moveComponent = unit.GetComponent<MoveComponent>();
            moveComponent.Stop(message.Error == 0);
            unit.Position = message.Position;
            unit.Rotation = message.Rotation;
            unit.GetComponent<ObjectWait>()?.Notify(new Wait_UnitStop() { Error = message.Error });
            await ETTask.CompletedTask;
        }
    }
}