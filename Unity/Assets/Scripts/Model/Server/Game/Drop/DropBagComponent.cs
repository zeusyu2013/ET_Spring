using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(Unit))]
    public class DropBagComponent : Entity, IAwake, IDestroy
    {
        public long BelongTeamId;

        public long BelongUnitId;

        public List<GameItemInfo> GameItems = new();

        public long Timer;
    }
}