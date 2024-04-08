namespace ET.Server
{
    [EntitySystemOf(typeof(Mail))]
    [FriendOfAttribute(typeof(ET.Server.Mail))]
    public static partial class MailSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.Mail self)
        {
        }

        public static MailInfo ToMessage(this Mail self)
        {
            MailInfo info = MailInfo.Create();
            info.Title = self.Title;
            info.Content = self.Content;
            info.Attachments = self.Attachments;
            info.Read = self.Read;
            info.ReceiveAttachments = self.ReceiveAttachments;

            return info;
        }
    }
}