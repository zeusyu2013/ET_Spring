using System.Collections.Generic;

namespace ET
{
    public class BagComponent : Entity
    {
        public int Capacity;
        
        public List<EntityRef<GameItem>> GameItems = new();
    }
}