namespace ET.Server
{
    [ChildOf(typeof(MonsterMapComponent))]
    public class CreateMonsterInfo : Entity, IAwake<int>
    {
        public int MonsterConfigId;
    }
}