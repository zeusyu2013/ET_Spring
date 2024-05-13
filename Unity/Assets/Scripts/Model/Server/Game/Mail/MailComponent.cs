using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(Unit))]
    public class MailComponent : Entity, IAwake, IDeserialize, ITransfer
    {
        public List<EntityRef<Mail>> Mails = new();
    }
}