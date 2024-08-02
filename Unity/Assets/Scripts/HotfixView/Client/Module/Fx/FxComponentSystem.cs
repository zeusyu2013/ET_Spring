namespace ET.Client
{
    [EntitySystemOf(typeof(FxComponent))]
    public static partial class FxComponentSystem
    {
        [EntitySystem]
        private static void Awake(this FxComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this FxComponent self)
        {
        }
    }
}