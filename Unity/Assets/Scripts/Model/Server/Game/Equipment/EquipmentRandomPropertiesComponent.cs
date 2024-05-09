using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(GameItem))]
    public class EquipmentRandomPropertiesComponent : Entity, IAwake
    {
        public Dictionary<int, long> RandomProperties = new();
    }
}