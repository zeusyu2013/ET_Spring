using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    [ChildOf(typeof(ActionTempComponent))]
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
        public Cast Cast => this.Parent.GetParent<Cast>();

        [BsonIgnore]
        public Buff Buff => this.Parent.GetParent<Buff>();

        [BsonIgnore]
        public BulletComponent BulletComponent => this.Parent.GetParent<BulletComponent>();
    }
}