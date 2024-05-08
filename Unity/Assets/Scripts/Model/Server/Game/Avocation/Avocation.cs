using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
    [ChildOf(typeof(AvocationComponent))]
    public class Avocation : Entity, IAwake<AvocationType>
    {
        public AvocationType AvocationType;

        public int Level;

        public long Exp;

        [BsonIgnore]
        public AvocationConfig Config => AvocationConfigCategory.Instance.Get(this.AvocationType);
    }
}