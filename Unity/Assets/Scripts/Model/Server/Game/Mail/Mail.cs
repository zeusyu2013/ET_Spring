using System.Collections.Generic;

namespace ET.Server
{
    [ChildOf(typeof(MailComponent))]
    public class Mail : Entity, IAwake
    {
        public string Title;

        public string Content;

        public List<GameItemInfo> Attachments;

        public bool Read;

        public bool ReceiveAttachments;
    }
}