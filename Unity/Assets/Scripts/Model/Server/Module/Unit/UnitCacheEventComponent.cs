using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(Scene))]
    public class UnitCacheEventComponent : Entity, IAwake
    {
        public List<string> CollectionNames = new();
    }  
}
