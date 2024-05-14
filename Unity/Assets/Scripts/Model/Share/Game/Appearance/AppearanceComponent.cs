namespace ET
{
    [ComponentOf(typeof(Unit))]
    public class AppearanceComponent : Entity, IAwake, ITransfer
    {
        public int ModelConfig;

        public int WeaponConfig;
    }
}