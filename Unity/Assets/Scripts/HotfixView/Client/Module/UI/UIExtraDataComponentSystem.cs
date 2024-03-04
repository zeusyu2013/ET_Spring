namespace ET.Client
{
    /// <summary>
    /// 来存放界面工作时的必要数据
    /// 为了不自己维护数据，为字典key增加一个命名规则
    /// 规则 ： key  --> 包含界面名字 例如给UILoagin界面存一些数据 可以命名 UILoagin  UILoaginxxx  UILoagin_xxx等
    /// </summary>
    [EntitySystemOf(typeof(UIExtraDataComponent))]
    [FriendOf(typeof(UIExtraDataComponent))]
    public static partial class UIExtraDataComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIExtraDataComponent self)
        {

        }
        [EntitySystem]
        private static void Destroy(this UIExtraDataComponent self)
        {
            self.ExtraDataDic.Clear();
            self.ExtraDataDic = null;
            self.Keys.Clear();
            self.Keys = null;
        }

        /// <summary>
        /// 设置临时数据
        /// </summary>
        /// <param name="self"></param>
        /// <param name="key">索引Key</param>
        /// <param name="param">参数</param>
        public static void SetUIData(this UIExtraDataComponent self, string key, params object[] param)
        {
            self.ExtraDataDic.TryGetValue(key, out var value);
            if (value == null)
            {
                self.ExtraDataDic.Add(key, param);
                self.Keys.Add(key);
            }
            self.ExtraDataDic[key] = param;
        }

        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="self"></param>
        /// <param name="key">界面名字</param>
        /// <returns>存的参数</returns>
        public static object[] GetUIData(this UIExtraDataComponent self, string key)
        {
            self.ExtraDataDic.TryGetValue(key, out var param);
            return param;
        }

        public static void ClearUIData(this UIExtraDataComponent self, string key)
        {
            int count = self.Keys.Count;
            for (int i = count - 1; i >= 0; i--)
            {
                if (self.Keys[i].Contains(key))
                {
                    self.ExtraDataDic.Remove(key);
                    self.Keys.RemoveAt(i);
                }
            }
        }
    }
}

