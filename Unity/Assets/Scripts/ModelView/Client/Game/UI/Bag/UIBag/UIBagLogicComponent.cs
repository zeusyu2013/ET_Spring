using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class UIBagLogicComponent: Entity, IAwake, IDestroy
    {
        public List<GameItemInfo> GameItemInfos;
    }
}