using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    [ChildOf(typeof(SoulComponent))]
    public class Soul : Entity, IAwake<int>, IDestroy, ISerializeToEntity
    {
        public int ConfigId;

        [BsonIgnore]
        public SoulConfig Config => SoulConfigCategory.Instance.Get(this.ConfigId);

        public int Level;

        public int Star;
    }
}