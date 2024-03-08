using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class UIServerListLogicComponent: Entity, IAwake, IDestroy
    {
        public List<Servers> ServersList = new();
        public List<Districts> DistrictsList = new();
    }
}