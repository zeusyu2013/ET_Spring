namespace ET.Server
{
    [ComponentOf(typeof(Unit))]
    public class BattleStateComponent : Entity, IAwake, IDestroy
    {
        public EntityRef<Unit> Target;
    }
}