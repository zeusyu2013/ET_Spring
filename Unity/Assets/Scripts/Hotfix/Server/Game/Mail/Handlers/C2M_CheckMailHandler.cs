namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    [FriendOfAttribute(typeof(ET.Server.Mail))]
    public class C2M_CheckMailHandler : MessageLocationHandler<Unit, C2M_CheckMail, M2C_CheckMail>
    {
        protected override async ETTask Run(Unit unit, C2M_CheckMail request, M2C_CheckMail response)
        {
            long mailId = request.MailId;
            if (mailId < 1)
            {
                response.Error = ErrorCode.ERR_MailIdInvalid;
                response.Message = "邮箱id无效";
                return;
            }

            Mail mail = unit.GetComponent<MailComponent>().CheckMail(mailId);
            if (mail == null)
            {
                response.Error = ErrorCode.ERR_MailIdNotFound;
                response.Message = "邮箱id未找到";
                return;
            }

            mail.Read = true;
            response.MailInfo = mail.ToMessage();

            await ETTask.CompletedTask;
        }
    }
}