namespace ET.Server
{
    [ComponentOf(typeof(Scene))]
    public class RoundBattleComponent : Entity, IAwake, IDestroy
    {
        public int PVEConfig;
        
        public EntityRef<Unit> Owner;

        public long SpeedTimer;
    }
}