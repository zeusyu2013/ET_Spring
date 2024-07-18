using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace ET
{
    [ComponentOf(typeof(Unit))]
    public class SkillComponent : Entity, IAwake, IDestroy
    {
        public List<int> Skills = new();
    }
}