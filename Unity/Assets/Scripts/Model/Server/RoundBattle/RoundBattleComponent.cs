using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(Scene))]
    public class RoundBattleComponent : Entity, IAwake<int>, IDestroy
    {
        public int ConfigId;
        
        public EntityRef<Unit> Owner;
        
        public List<EntityRef<Unit>> Units = new();

        public long BattleSpeedTimer;

        public bool Pause;
    }
}