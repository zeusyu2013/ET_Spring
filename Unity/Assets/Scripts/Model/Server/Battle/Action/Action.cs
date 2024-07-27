using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    [ChildOf]
    public class Action : Entity, IAwake<int>, IDestroy, ISerializeToEntity
    {
        public int ConfigId;

        [BsonIgnore]
        public ActionConfig Config => ActionConfigCategory.Instance.Get(this.ConfigId);

        [BsonIgnore]
        public EntityRef<Unit> Caster;

        [BsonIgnore]
        public EntityRef<Unit> Owner;

        [BsonIgnore]
        public Skill Skill => this.Parent.GetParent<Skill>();

        [BsonIgnore]
        public EntityRef<GameBuff> Buff => this.Parent.GetParent<GameBuff>();
    }
}