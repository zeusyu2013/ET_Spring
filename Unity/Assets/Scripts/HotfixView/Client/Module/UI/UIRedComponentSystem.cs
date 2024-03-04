namespace ET.Client
{
    /// <summary>
    /// 界面红点组件 挂在再UI上
    /// </summary>
    [EntitySystemOf(typeof(UIRedComponent))]
    [FriendOf(typeof(UIRedComponent))]
    public static partial class UIRedComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIRedComponent self)
        {

        }
        [EntitySystem]
        private static void Destroy(this UIRedComponent self)
        {

        }

        /// <summary>
        /// 显示界面红点
        /// </summary>
        /// <param name="self"></param>
        public static void ShowRedPoint(this UIRedComponent self)
        {
            
        }
    }
}

