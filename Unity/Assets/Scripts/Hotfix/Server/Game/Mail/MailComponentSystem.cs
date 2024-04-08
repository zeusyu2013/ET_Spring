namespace ET.Server
{
    [EntitySystemOf(typeof(MailComponent))]
    [FriendOfAttribute(typeof(ET.Server.MailComponent))]
    [FriendOfAttribute(typeof(ET.Server.Mail))]
    public static partial class MailComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.MailComponent self)
        {
        }

        public static void AddMail(this MailComponent self, Mail mail)
        {
            self.Mails.Add(mail);
        }

        public static Mail CheckMail(this MailComponent self, long mailId)
        {
            Mail mail = null;
            foreach (var entityRef in self.Mails)
            {
                Mail temp = entityRef;
                if (mailId == temp.Id)
                {
                    mail = temp;
                    mail.Read = true;
                    break;
                }
            }

            return mail;
        }

        public static Mail ReceiveMailAttachments(this MailComponent self, long mailId)
        {
            Mail mail = null;
            foreach (var entityRef in self.Mails)
            {
                Mail temp = entityRef;
                if (mailId == temp.Id)
                {
                    mail = temp;
                    mail.ReceiveAttachments = true;
                    // todo:发放邮件附件内的道具
                    break;
                }
            }

            return mail;
        }

        public static void ClearMails(this MailComponent self)
        {
            self.Mails.Clear();
        }

        [EntitySystem]
        private static void Deserialize(this ET.Server.MailComponent self)
        {
            self.ClearMails();

            foreach (Entity childrenValue in self.Children.Values)
            {
                Mail mail = childrenValue as Mail;

                self.Mails.Add(mail);
            }
        }
    }
}