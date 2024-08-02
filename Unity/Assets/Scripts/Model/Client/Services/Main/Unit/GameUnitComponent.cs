namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class GameUnitComponent : Entity, IAwake
    {
        public long UnitId { get; set; }
    }
}
