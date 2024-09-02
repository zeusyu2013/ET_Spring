using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    [ChildOf(typeof(SoulRuneComponent))]
    public class SoulRune : Entity, IAwake<int>, IDestroy, ISerializeToEntity
    {
        public int ConfigId;

        [BsonIgnore]
        public SoulRuneConfig Config => SoulRuneConfigCategory.Instance.Get(this.ConfigId);
    }
}