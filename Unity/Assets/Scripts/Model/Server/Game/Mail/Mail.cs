using System.Collections.Generic;

namespace ET.Server
{
    [ChildOf(typeof(MailComponent))]
    public class Mail : Entity, IAwake, ISerializeToEntity
    {
        public string Title;

        public string Content;

        public List<GameItemInfo> Attachments;

        public bool Read;

        public bool ReceiveAttachments;
    }
}