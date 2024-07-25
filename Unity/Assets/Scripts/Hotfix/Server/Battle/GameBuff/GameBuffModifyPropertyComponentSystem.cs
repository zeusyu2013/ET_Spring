namespace ET.Server
{
    [EntitySystemOf(typeof(GameBuffModifyPropertyComponent))]
    public static partial class GameBuffModifyPropertyComponentSystem
    {
        [EntitySystem]
        private static void Awake(this GameBuffModifyPropertyComponent self)
        {
            BuffModifyPropertyParams modifyPropertyParams = (BuffModifyPropertyParams)self.GetParent<GameBuff>().Config.Parameters;

            self.GetParent<Unit>().GetComponent<NumericComponent>()[modifyPropertyParams.Property] += modifyPropertyParams.Value;
        }

        [EntitySystem]
        private static void Destroy(this GameBuffModifyPropertyComponent self)
        {
            BuffModifyPropertyParams modifyPropertyParams = (BuffModifyPropertyParams)self.GetParent<GameBuff>().Config.Parameters;

            self.GetParent<Unit>().GetComponent<NumericComponent>()[modifyPropertyParams.Property] -= modifyPropertyParams.Value;
        }
    }
}