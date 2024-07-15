using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf]
    public class DungeonComponent : Entity, IAwake, IDestroy
    {
        public Dictionary<long, EntityRef<Scene>> DungeonScenes = new();
    }
}