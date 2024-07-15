namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    [FriendOfAttribute(typeof(ET.Server.MailComponent))]
    [FriendOfAttribute(typeof(ET.Server.Mail))]
    public class C2M_CheckMailsHandler : MessageLocationHandler<Unit, C2M_CheckMails, M2C_CheckMails>
    {
        protected override async ETTask Run(Unit unit, C2M_CheckMails request, M2C_CheckMails response)
        {
            foreach (var entityRef in unit.GetComponent<MailComponent>().Mails)
            {
                Mail mail = entityRef;
                mail.Read = true;
                response.MailInfos.Add(mail.ToMessage());
            }

            await ETTask.CompletedTask;
        }
    }
}