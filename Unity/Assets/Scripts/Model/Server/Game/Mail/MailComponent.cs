using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(Unit))]
    public class MailComponent : Entity, IAwake, IDeserialize
    {
        public List<EntityRef<Mail>> Mails = new();
    }
}