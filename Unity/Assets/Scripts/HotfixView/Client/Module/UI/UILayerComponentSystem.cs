
using FairyGUI;

namespace ET.Client
{
    [EntitySystemOf(typeof(UILayerComponent))]
    [FriendOf(typeof(UILayerComponent))]
    public static partial class UILayerComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UILayerComponent self)
        {

        }

        [EntitySystem]
        private static void Destroy(this UILayerComponent self)
        {
            foreach (var data in self.UILayer)
            {
                data.Value.Dispose();
            }
            self.UILayer = null;
        }

        /// <summary>
        /// 根据层级所在的组件
        /// </summary>
        /// <param name="self"></param>
        /// <param name="layer"></param>
        /// <returns></returns>
        public static GComponent GetLayerComponet(this UILayerComponent self, int layer)
        {
            // 看缓存中是否存在
            self.UILayer.TryGetValue(layer, out var component);
            if (component != null)
            {
                return component;
            }
            // 根据当前传入的层级创建分层组件
            for (int i = 0; i <= layer; i++)
            {
                if (!self.UILayer.ContainsKey(i))
                {
                    component = new GComponent
                    {
                        gameObjectName = $"Layer{i}"
                    };
                    self.UILayer.Add(i, component);
                    GRoot.inst.AddChild(component);
                }
            }

            return component;
        }
     
    }
}
