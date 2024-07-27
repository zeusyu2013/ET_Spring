using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    [ChildOf(typeof(SkillComponent))]
    public class Skill : Entity, IAwake<int, int>, IDestroy
    {
        public int ConfigId;

        public int Level;

        public EntityRef<Unit> Caster;

        public long StartTime;

        [BsonIgnore]
        public SkillConfig SkillConfig => SkillConfigCategory.Instance.Get(this.ConfigId, this.Level);

        [BsonIgnore]
        public List<long> Targets = new();
    }
}