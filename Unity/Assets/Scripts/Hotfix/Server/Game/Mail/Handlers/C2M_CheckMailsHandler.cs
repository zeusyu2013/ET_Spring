namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    [FriendOfAttribute(typeof(ET.Server.MailComponent))]
    public class C2M_CheckMailsHandler : MessageLocationHandler<Unit, C2M_CheckMails, M2C_CheckMails>
    {
        protected override async ETTask Run(Unit unit, C2M_CheckMails request, M2C_CheckMails response)
        {
            foreach (var entityRef in unit.GetComponent<MailComponent>().Mails)
            {
                Mail mail = entityRef;
                response.MailInfos.Add(mail.ToMessage());
            }

            await ETTask.CompletedTask;
        }
    }
}