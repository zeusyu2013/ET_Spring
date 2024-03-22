namespace ET
{
    [EntitySystemOf(typeof(GameBuffModifyPropertyComponent))]
    public static partial class GameBuffModifyPropertyComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.GameBuffModifyPropertyComponent self)
        {
            GameBuff buff = self.GetParent<GameBuff>();
            int propertyType = buff.Config.Parameters[0];
            int value = buff.Config.Parameters[1];

            self.GetParent<Unit>().GetComponent<NumericComponent>()[propertyType] += value;
        }

        [EntitySystem]
        private static void Destroy(this ET.GameBuffModifyPropertyComponent self)
        {
            GameBuff buff = self.GetParent<GameBuff>();
            int propertyType = buff.Config.Parameters[0];
            int value = buff.Config.Parameters[1];

            self.GetParent<Unit>().GetComponent<NumericComponent>()[propertyType] -= value;
        }
    }
}