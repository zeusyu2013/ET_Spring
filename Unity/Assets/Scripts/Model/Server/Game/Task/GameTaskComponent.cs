using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    [UnitCacheEvent(typeof(GameTaskComponent))]
    [ComponentOf(typeof(Unit))]
    public class GameTaskComponent : Entity, IAwake, ITransfer
    {
        public List<int> AcceptedTasks = new();
        
        public List<int> CompletedTasks = new();
    }
}