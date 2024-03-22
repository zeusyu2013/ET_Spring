using System.Collections.Generic;

namespace ET
{
    [ComponentOf(typeof(Unit))]
    public class GameBuffComponent : Entity, IAwake, IUpdate, IDestroy, ITransfer, ISerializeToEntity, IDeserialize
    {
        public List<EntityRef<GameBuff>> GameBuffs = new();
    }
}