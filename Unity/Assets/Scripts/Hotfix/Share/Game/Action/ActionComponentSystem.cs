namespace ET
{
    [EntitySystemOf(typeof(ActionComponent))]
    public static partial class ActionComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.ActionComponent self)
        {
        }
    }
}