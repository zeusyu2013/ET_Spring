using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf]
    public class UIComponent : Entity, IAwake
    {
        // 界面缓存列表
        public Dictionary<string, EntityRef<UI>> UIs = new();
    }
}