using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIComponent))]
    public class UIExtraDataComponent : Entity, IAwake, IDestroy
    {
        public Dictionary<string, object[]> ExtraDataDic = new();
        public List<string> Keys = new();
    }  
}
