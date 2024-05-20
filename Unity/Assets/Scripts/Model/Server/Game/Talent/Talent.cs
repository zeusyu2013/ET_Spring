using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    [ChildOf(typeof(TalentComponent))]
    public class Talent : Entity, IAwake<int>, IDestroy, ISerializeToEntity
    {
        public int ConfigId;

        public int Level;

        [BsonIgnore]
        public TalentConfig Config => TalentConfigCategory.Instance.Get(this.ConfigId);
    }
}