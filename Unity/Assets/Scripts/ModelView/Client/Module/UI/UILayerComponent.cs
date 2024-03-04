
using System.Collections.Generic;
using FairyGUI;

namespace ET.Client
{
    [ComponentOf(typeof(UIComponent))]
    public class UILayerComponent : Entity, IAwake, IDestroy
    {
        public Dictionary<int, GComponent> UILayer = new();
    }
}
