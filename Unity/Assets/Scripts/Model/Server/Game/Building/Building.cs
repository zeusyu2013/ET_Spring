using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    [ChildOf(typeof(BuildingComponent))]
    public class Building : Entity, IAwake<int>, ISerializeToEntity
    {
        public int ConfigId;

        public int Level;

        [BsonIgnore]
        public BuildingConfig Config => BuildingConfigCategory.Instance.Get(this.ConfigId);
    }
}