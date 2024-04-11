namespace ET.Client
{
    [EntitySystemOf(typeof(UIChatMiniLogicComponent))]
    [FriendOf(typeof(UIChatMiniLogicComponent))]
    public static partial class UIChatMiniLogicComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIChatMiniLogicComponent self)
        {
        }
        [EntitySystem]
        private static void Destroy(this UIChatMiniLogicComponent self)
        {
        }
        public static void OnHide(this UIChatMiniLogicComponent self)
        {
        }

        public static void OnShow(this UIChatMiniLogicComponent self)
        {
        }
    }
}