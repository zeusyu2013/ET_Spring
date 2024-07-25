using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(Unit))]
    [UnitCacheEvent(typeof(GameBuffComponent))]
    public class GameBuffComponent : Entity, IAwake, IUpdate, IDestroy, ITransfer, IDeserialize
    {
        public List<EntityRef<GameBuff>> GameBuffs = new();
    }
}