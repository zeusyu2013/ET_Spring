using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    [UnitCacheEvent(typeof(MailComponent))]
    [ComponentOf(typeof(Unit))]
    public class MailComponent : Entity, IAwake, IDeserialize, ITransfer
    {
        [BsonIgnore]
        public List<EntityRef<Mail>> Mails = new();
    }
}