namespace ET
{
    [ComponentOf(typeof(Unit))]
    public class AppearanceComponent : Entity, IAwake, ISerializeToEntity
    {
        public int ModelConfig;

        public int WeaponConfig;
    }
}