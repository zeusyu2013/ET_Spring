namespace ET.Client
{
    /// <summary>
    /// 界面动画组件 挂在再UI上
    /// </summary>
    [EntitySystemOf(typeof(UITweenComponent))]
    [FriendOf(typeof(UITweenComponent))]
    public static partial class UITweenComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UITweenComponent self)
        {
            
        }

        [EntitySystem]
        private static void Destroy(this UITweenComponent self)
        {
            
        }

        /// <summary>
        /// 播放入场动画
        /// </summary>
        /// <param name="self"></param>
        public static async ETTask PlayEnterTween(this UITweenComponent self)
        {
            await ETTask.CompletedTask;
        }

        /// <summary>
        /// 播放退场动画
        /// </summary>
        /// <param name="self"></param>
        public static async ETTask  PlayExistTween(this UITweenComponent self)
        {
            await ETTask.CompletedTask;
        }
    }
}


