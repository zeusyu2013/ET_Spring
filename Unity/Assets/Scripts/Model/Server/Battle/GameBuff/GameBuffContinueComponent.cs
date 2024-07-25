namespace ET.Server
{
    [ComponentOf(typeof(GameBuff))]
    public class GameBuffContinueComponent : Entity, IAwake, IDestroy, IUpdate
    {
        public long Time;
    }
}