namespace ET.Server
{
    [ComponentOf(typeof(Unit))]
    public class PlayerLevelComponent : Entity
    {
        public int Level;
        public long Exp;
        public long MaxExp;
    }
}